using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 10f;
        public Transform point;

        public event System.Action onCollitionStone;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private bool m_isDown = false;

        public void Down()
        {
            m_isDown = false;
        }
        
        public void Up()
        {
            m_isDown = true;
        }

        void Update()
        {
            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty)
            {
                stone.isDirty = true;
                var constact = other.contacts[0];
                other.rigidbody.AddForce(m_dir * power, ForceMode.Impulse);
                onCollitionStone?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (m_isDown)
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
            }

            transform.localEulerAngles = angle;
        }
    }
}
