using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Transform stick;
        public float maxAngle = 30f;
        public float speed = 50f;

        private void Update()
        {
            Vector3 angle = stick.localEulerAngles;
            if (Input.GetMouseButton(0))
            {
                angle.z += speed * Time.deltaTime;
                angle.z = Mathf.Min(angle.z, maxAngle);
            }
            else
            {
                angle.z -= speed * Time.deltaTime;
                angle.z = Mathf.Max(angle.z, -maxAngle);
            }

            stick.localEulerAngles = angle;
        }
    }
}
