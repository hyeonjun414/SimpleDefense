namespace GameAsset.Scripts.Core
{
    public class Stage
    {
        public string MasterId;
        public string SpawnEnemy;
        public int EnemyCount;
        public int Time;

        public Stage(MasterStage ms)
        {
            MasterId = ms.Id;
            SpawnEnemy = ms.SpawnEnemy;
            EnemyCount = ms.EnemyCount;
            Time = ms.Time;
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
