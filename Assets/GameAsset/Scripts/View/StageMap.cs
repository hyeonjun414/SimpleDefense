using System.Collections;
using System.Collections.Generic;
using GameAsset.Scripts.Core;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class StageMap : MonoBehaviour
    {
        public Transform startPoint;
        public List<Transform> wayPoints = new();
        public EnemySpawner enemySpawner;

        private Stage curStage;

        public void StageStart(Stage _stage)
        {
            curStage = _stage;
            StartCoroutine(nameof(SpawnRoutine));
        }

        public IEnumerator SpawnRoutine()
        {
            for (var i = 0; i < curStage.EnemyCount; i++)
            {
                    enemySpawner.Spawn();
                    yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
