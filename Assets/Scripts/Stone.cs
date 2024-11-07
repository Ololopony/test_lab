using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public event Action onCollisionStone;
        public event Action onEnterTriggerWall;
        public bool isDirty = false;

        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.isDirty = true;

                onCollisionStone?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            onEnterTriggerWall?.Invoke();
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}