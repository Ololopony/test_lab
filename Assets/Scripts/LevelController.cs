using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;
        [SerializeField] float m_delay = 2f;
        private List<Stone> m_stones = new List<Stone>();

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollitionStone += OnCollisionStick;
        }

        void OnDisable()
        {
            if (stick != null)
            {
                stick.onCollitionStone -= OnCollisionStone;
            }
        }

        private void Update()
        {
            if (Time.time > m_timer + m_delay)
            {
                m_timer = Time.time;

                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();

                stone.onCollitionStone += OnCollisionStone;

                m_stones.Add(stone);
            }
        }

        private void OnCollisionStone()
        {
            Debug.Log("Game Over");
        }

        private void OnCollisionStick()
        {
            Debug.Log("OnCollisionStick");
        }
    }
}
