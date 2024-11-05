using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public void Show()
        {
            gameObject.SetActive(true);
        }

        void OnEnable()
        {
            rootUI.SetActive(true);
        }

        void OnDisable()
        {
            rootUI.SetActive(false);
        }
    }
}
