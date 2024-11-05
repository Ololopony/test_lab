using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        public GameOverState gameOverState;
        public PlayerController playerController;
        public LevelController levelController;
        public GameObject rootUI;
        public TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            rootUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;

            levelController.onGameOver += OnGameOver;
            levelController.onScoreInc += OnScoreInc;

            OnScoreInc(0);
        }

        private void OnGameOver()
        {
            gameObject.SetActive(false);
            gameOverState.Show();
        }

        private void OnScoreInc(uint score)
        {
            scoreText.text = $"SCORE: {score}";
        }

        private void OnDisable()
        {
            rootUI.SetActive(false);
            playerController.enabled = false;
            levelController.enabled = false;
        }

        public void Play()
        {
            gameObject.SetActive(true);
        }
    }
}
