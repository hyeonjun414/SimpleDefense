using System;
using GameAsset.Scripts.Core;
using TMPro;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class UIStageInfo : MonoBehaviour
    {
        public TextMeshProUGUI textStage, textTime, textEnemy, textKillCount, textGold;


        public void UpdateStageInfo(Stage stage)
        {
            textStage.text = $"STAGE {stage.StageLevel}";
            textTime.text = Math.Ceiling(stage.Time).ToString();
            textEnemy.text = stage.RemainEnemyCount.ToString();
        }

        public void UpdateKillCount(int killcount)
        {
            textKillCount.text = killcount.ToString();
        }

        public void UpdateGold(int gold)
        {
            textGold.text = gold.ToString();
        }
    }
}
