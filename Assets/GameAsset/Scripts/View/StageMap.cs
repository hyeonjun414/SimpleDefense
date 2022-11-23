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

        public List<EnemyView> createdEnemies = new();

        public void StageStart(Stage _stage)
        {
            stage = _stage;
            UpdateStage();
            StartCoroutine(nameof(SpawnRoutine));
        }

        public IEnumerator SpawnRoutine()
        {
            Door.SetActive(true);
            yield return new WaitForSeconds(1f);
            var enemy = GameMaster.Instance.masterTable.MasterEnemies[0];
            for (var i = 0; i < stage.EnemyCount; i++)
            {
                createdEnemies.Add(enemySpawner.Spawn(enemy));
                GameMaster.Instance.SpawnedEnemy();
                yield return new WaitForSeconds(1f);
            }
            Door.SetActive(false);
            yield return null;
        }

        public void UpdateStage()
        {
            GameMaster.Instance.uiManager.UpdateStageInfo(stage);
        }

        public void EnemyDie(EnemyView enemy)
        {
            createdEnemies.Remove(enemy);
            GameMaster.Instance.EnemyDead();
        }

        public void GameOver()
        {
           StopAllCoroutines();
           foreach (var enemy in createdEnemies)
           {
               Destroy(enemy.gameObject);
           }
           createdEnemies.Clear();
        }
    }
}
