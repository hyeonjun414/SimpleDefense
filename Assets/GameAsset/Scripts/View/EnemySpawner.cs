using System;
using System.Collections.Generic;
using GameAsset.Scripts.Core;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class EnemySpawner : MonoBehaviour
    {
        public Enemy enemyPrefab;
        public StageMap stageMap;         
        private Stage curStage;

        private List<Enemy> createdEnemies= new();

        public void SpawnStart()
        {
            Instantiate(enemyPrefab, stageMap.startPoint).Move(stageMap.wayPoints);                 
        }

        public void TimeOver()
        {
            foreach (var enemy in createdEnemies)
            {
                Destroy(enemy.gameObject);
            }              
        }

        public void Spawn()
        {
            Instantiate(enemyPrefab, stageMap.startPoint).Move(stageMap.wayPoints);         
        }
    }
}
