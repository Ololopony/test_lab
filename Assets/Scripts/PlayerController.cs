using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public SoundController soundController;
        public Stick stick;
        public GolfAnimatorController golfAnimator;

        private void FixedUpdate()
        {
            // if (Input.GetMouseButton(0))
            // {   
            //     PointerDown();
            // }
            // else
            // {
            //     PointerUp();
            // }
        }

        public void PointerDown()
        {
            soundController.PlayAudio(soundController.swingAudio);
            stick.Down();
            golfAnimator.BackwardsAnimation();
        }

        public void PointerUp()
        {
            soundController.PlayAudio(soundController.swingAudio);
            stick.Up();
            golfAnimator.ForwardAnimation();
        }
    }
}
