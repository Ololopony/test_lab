using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public event Action onCollitionStone;
        public bool isDirty = false;

        void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if(other.gameObject.GetComponent<Stick>())
            {
                onCollitionStone?.Invoke();
            }
        }
    }
}
