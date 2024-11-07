using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform m_point;
    
    [SerializeField]
    private GameObject[] m_Prefabs;

    private void Start()
    {
        if (m_point == null)
        {
            m_point = transform;
        }
    }

    public GameObject Spawn()
    {
        return Instantiate(m_Prefabs[0], m_point.position, m_point.rotation);
    }
}
