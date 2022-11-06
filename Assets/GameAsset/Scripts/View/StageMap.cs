using System.Collections;
using System.Collections.Generic;
using GameAsset.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class StageMap : MonoBehaviour
    {
        public Transform startPoint;
        public List<Transform> wayPoints = new();
        public EnemySpawner enemySpawner;
        public GameObject Door;
        private Stage stage;

        public List<Enemy> createdEnemies = new();

        public void StageStart(Stage _stage)
        {
            stage = _stage;
            UpdateStage();
            StartCoroutine(nameof(SpawnRoutine));
            StartCoroutine(nameof(StartTime));
        }

        public IEnumerator StartTime()
        {
            UpdateStage();
            float sec = 0;
            while (true)
            {
                sec += Time.deltaTime;
                stage.Time -= Time.deltaTime;
                if (sec >= 1f)
                {
                    sec = 0;
                    UpdateStage();
                }
                yield return null;
            }
            
        }

        public IEnumerator SpawnRoutine()
        {
            Door.SetActive(true);
            yield return new WaitForSeconds(1f);
            
            for (var i = 0; i < stage.EnemyCount; i++)
            {
                createdEnemies.Add(enemySpawner.Spawn());
                stage.RemainEnemyCount = createdEnemies.Count;
                UpdateStage();
                yield return new WaitForSeconds(1f);
            }
            Door.SetActive(false);
            yield return null;
        }

        public void UpdateStage()
        {
            GameMaster.Instance.stageUI.UpdateStageInfo(stage);
        }
    }
}
