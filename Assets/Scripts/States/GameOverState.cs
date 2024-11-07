using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;
        public GameObject winTextObj;
        public TMPro.TextMeshProUGUI winText;

        private void OnEnable()
        {
            rootUI.SetActive(true);           
            
            if (GameInstance.scoredMore)
            {
                winTextObj.SetActive(true);
                winText.text = $"New High Score: {GameInstance.score}";
            }
        }

        private void OnDisable()
        {
            if (winTextObj)
            {
                winTextObj.SetActive(false);
            }
            if (rootUI)
            {
                rootUI.SetActive(false);
            }
            GameInstance.scoredMore = false;
        }
        

        public void Restart()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void BackToManinMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
