namespace GameAsset.Scripts.Core
{
    public class Stage
    {
        public string MasterId;
        public string SpawnEnemy;
        public int StageLevel;
        public int EnemyCount;
        public int RemainEnemyCount;
        public int KillCount;
        public float Time;

        public Stage(MasterStage ms)
        {
            MasterId = ms.Id;
            StageLevel = ms.StageNumber;
            SpawnEnemy = ms.SpawnEnemy;
            EnemyCount = ms.EnemyCount;
            Time = ms.Time;
            RemainEnemyCount = 0;
        }
    }
    
    public class Unit
    {
    }

    public class Enemy : Unit
    {
        public int HP;
        public int Defense;
        public int MoveSpeed;
    }

    public class Hero : Unit
    {
        
    }
}
