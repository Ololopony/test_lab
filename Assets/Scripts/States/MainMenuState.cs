using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public SettingsMenuState settingsMenuState;
        public GameObject mainMenuUI;
        public GamePlayState gamePlayState;
        public TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            mainMenuUI.SetActive(true);

            scoreText.text = $"TOP SCORE: {GameInstance.score}";
        }

        private void OnDisable()
        {
            if (mainMenuUI)
            {
                mainMenuUI.SetActive(false);
            }
        }

        public void Play()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void ToSettings()
        {
            gameObject.SetActive(false);
            settingsMenuState.gameObject.SetActive(true);
        }
    }
}
