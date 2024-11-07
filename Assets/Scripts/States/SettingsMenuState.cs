using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class SettingsMenuState : MonoBehaviour
    {
        public AudioSource backgroundMusic;
        public SoundController soundController;
        public GameObject settingsMenuUI;
        public MainMenuState mainMenuState;
        public Slider sound;
        public Slider music;

        private void OnEnable()
        {
            settingsMenuUI.SetActive(true);
        }

        private void OnDisable()
        {
            settingsMenuUI.SetActive(false);
        }

        public void BacktoMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }

        private void Start()
        {
            sound.value = soundController.rockHitAudio.volume;
            music.value = backgroundMusic.volume;
            sound.onValueChanged.AddListener((value) => {
                soundController.rockHitAudio.volume = value;
                soundController.swingAudio.volume = value;
            });    
            music.onValueChanged.AddListener((value) => {
                backgroundMusic.volume = value;
            });
        }
    }
}
