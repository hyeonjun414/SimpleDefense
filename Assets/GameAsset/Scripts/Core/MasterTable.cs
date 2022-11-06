using System;
using System.Collections.Generic;

namespace GameAsset.Scripts.Core
{
    [Serializable]
    public class MasterTable
    {
        public List<MasterEnemy> MasterEnemies;
        public List<MasterStage> MasterStages;
    }

    [Serializable]
    public class MasterStage
    {
        public string Id;
        public int StageNumber;
        public string SpawnEnemy;
        public int EnemyCount;
        public int Time;
    }
    
    [Serializable]
    public class MasterEnemy
    {
        public string Id;
        public string Name, Desc;
        public int Hp;
        public double MoveSpeed;
    }
}
