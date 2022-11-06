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
        
        public Enemy Spawn()
        {
            var enemy = Instantiate(enemyPrefab, stageMap.startPoint);
            enemy.Move(stageMap.wayPoints);
            return enemy;         
        }
    }
}
