using System;
using GameAsset.Scripts.Core;
using TMPro;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI textStage, textTime, textEnemy, textKillCount, textGold;

        public GameObject gameOverPanel;

        public void UpdateStageInfo(Stage stage)
        {
            textStage.text = $"STAGE {stage.StageLevel}";
        }

        public void UpdateKillCount(int killcount)
        {
            textKillCount.text = killcount.ToString();
        }

        public void UpdateGold(int gold)
        {
            textGold.text = gold.ToString();
        }

        public void UpdateTime(float time)
        {
            textTime.text = Math.Ceiling(time).ToString();
        }

        public void UpdateRemainEnemy(int remainCount)
        {
            textEnemy.text = remainCount.ToString();
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
