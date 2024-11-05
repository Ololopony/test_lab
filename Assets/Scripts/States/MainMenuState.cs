using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public GamePlayState gamePlayState;
        public TextMeshProUGUI scoreText;

        void OnEnable()
        {
            mainMenuUI.SetActive(true);
            scoreText.text = $"TOP SCORE: {GameInstance.score}";            
        }

        void OnDisable()
        {
            mainMenuUI.SetActive(false);    
        }

        public void Play()
        {
            this.gameObject.SetActive(false);
            gamePlayState.Play();
        }
    }
}
