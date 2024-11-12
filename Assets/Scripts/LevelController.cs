using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Golf;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public MainCameraScript cam;
        private static GameDiff m_gameDiff;
        public SoundController soundController;
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;
        private int m_stonesByTen = 0;
        private int m_score = 0;

        private List<Stone> m_stones = new List<Stone>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        private void Start()
        {
            //string json = JsonUtility.ToJson(gameDiff);
            //File.WriteAllText(Application.dataPath + "/DifficultySettings/difficultyFile.json", json);
            var asset = Resources.Load<TextAsset>("DifficultySettings/difficultyFile");
            string json = asset.text;
            m_gameDiff = JsonUtility.FromJson<GameDiff>(json);
        }

        public void OnEnable()
        {
            stick.onCollisionStone += OnCollisionStick;

            m_score = 0;

            ClearStones();
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStick;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                if (stone)
                {
                    Destroy(stone.gameObject);
                }
            }

            m_stones.Clear();
        }

        private void Update()
        {
            if (Time.time > m_timer + m_gameDiff.delay)
            {
                m_timer = Time.time;

                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();

                stone.onCollisionStone += OnCollisionStone;
                stone.onEnterTriggerWall += OnBonusWallTrigger;

                m_stones.Add(stone);
                m_stonesByTen++;

                if (m_stonesByTen == 10 && m_gameDiff.delay != m_gameDiff.maxDelayChange)
                {
                    m_stonesByTen = 0;
                    m_gameDiff.delay -= m_gameDiff.stepDelay;
                }
            }
        }

        private void OnBonusWallTrigger()
        {
            m_score++;
            Debug.Log($"bonus score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStick()
        {
            soundController.PlayAudio(soundController.rockHitAudio);
            m_score++; 
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
        }
    }
}