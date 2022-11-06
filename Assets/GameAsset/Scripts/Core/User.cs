namespace GameAsset.Scripts.Core
{
    public class User
    {
        public int Gold;
        public int Hp;
        public int MaxHp;

        public User()
        {
            Gold = 0;
            MaxHp = 30;
            Hp = MaxHp;
        }
    }
}
