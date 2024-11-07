using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class MainCameraScript : MonoBehaviour
    {
        private Vector3 destPos;
        private Quaternion destRot;
        public GameObject mainMenuState;
        public GameObject gamePlayState;
        public Transform mainMenuDest;
        public Transform gamePlatDest;
        private float speed = 20f;
        private bool m_toMove = false;

        private void Update()
        {
            if (m_toMove)
            {
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destPos, step);

                transform.rotation = Quaternion.Slerp(transform.rotation, destRot, step);

                if (transform.position == destPos && transform.rotation == destRot)
                {
                    m_toMove = false;
                }
            }

            if (mainMenuState.activeSelf == true)
            {
                Move(mainMenuDest);
            }

            if (gamePlayState.activeSelf == true)
            {
                Move(gamePlatDest);
            }
        }

        public void Move(Transform destanation)
        {
            destPos = destanation.position;
            destRot = destanation.rotation;
            m_toMove = true;
        }
    }
}
