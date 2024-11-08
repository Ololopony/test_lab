using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public SoundController soundController;
        public Stick stick;
        public GolfAnimatorController golfAnimator;

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
