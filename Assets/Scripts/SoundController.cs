using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class SoundController : MonoBehaviour
    {
        public AudioSource rockHitAudio, swingAudio;

        public void PlayAudio(AudioSource audio)
        {
            audio.Play();
        }
    }
}
