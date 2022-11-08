using System;
using System.Collections.Generic;
using GameAsset.Scripts.Core;
using UnityEngine;
using Enemy = GameAsset.Scripts.Core.Enemy;

namespace GameAsset.Scripts.View
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemyView enemyPrefab;
        public StageMap stageMap;
        
        public EnemyView Spawn(MasterEnemy masterEnemy)
        {
            var enemy = Instantiate(enemyPrefab, stageMap.startPoint);
            enemy.origin = new Enemy(masterEnemy);
            enemy.Move(stageMap.wayPoints);
            return enemy;         
        }
    }
}
