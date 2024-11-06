using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace Golf
{
    public class GolfAnimatorController : MonoBehaviour
    {
        [SerializeField]
        private Animator mAnimator;

        public void ForwardAnimation()
        {
            mAnimator.SetTrigger("Forward");
        }

        public void BackwardsAnimation()
        {
            mAnimator.SetTrigger("Back");
        }
    }
}
