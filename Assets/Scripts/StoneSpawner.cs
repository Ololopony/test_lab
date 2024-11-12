using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform m_point;
    
    [SerializeField]
    private GameObject m_Prefab;

    private void Start()
    {
        if (m_point == null)
        {
            m_point = transform;
        }
    }

    public GameObject Spawn()
    {
        return Instantiate(m_Prefab, m_point.position, m_point.rotation);
    }
}
