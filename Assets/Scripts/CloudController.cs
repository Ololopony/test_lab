using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Transform m_cloud;
    [SerializeField] private Transform[] m_points;
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private GameObject m_rain;

    private int m_curPointIndex = -1;
    private bool m_isMove = false;

    public void MoveNext()
    {
        m_rain.SetActive(false);
        if (m_curPointIndex >= 0)
        {
            m_curPointIndex++;

            if (m_curPointIndex >= m_points.Length)
            {
                m_curPointIndex = 0;
            }
        }
        else
        {
           m_curPointIndex = 0;
        }

        m_isMove = true;
    }

    private Vector3 GetPoint(int index)
    {
        var point = m_points[index].position;
        point.y = m_cloud.position.y;
        return point;
    }

    private void Update()
    {
        if (!m_isMove)
        {
            m_rain.SetActive(true);
            return;
        }

        var point = GetPoint(m_curPointIndex);
        m_cloud.position = Vector3.Lerp(m_cloud.position, point, Time.deltaTime * m_speed);
        if (Vector3.Distance(m_cloud.position, point) < 1f)
        {
            m_isMove = false;
        }
    }
}
