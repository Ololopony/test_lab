using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public StoneSpawner stoneSpawner;
    private float m_timer;
    [SerializeField] float m_delay = 2f;

    public void OnEnable()
    {
        m_timer = Time.time;
    }

    private void Update()
    {
        if (Time.time > m_timer + m_delay)
        {
            stoneSpawner.Spawn();
            m_timer = Time.time;
        }
    }
}
