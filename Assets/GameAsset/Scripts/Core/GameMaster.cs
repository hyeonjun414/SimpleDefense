using System;
using GameAsset.Scripts.View;
using LitJson;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameAsset.Scripts.Core
{
    public class GameMaster : MonoBehaviour
    {
        private static GameMaster _instance;

        public static GameMaster Instance => _instance;

        public StageMap stage;

        public MasterTable masterTable;
        public User user;
        public int stageLevel = 0;
        public UIStageInfo stageUI;
        public int KillCount = 0;
        public void Awake()
        {
            if (_instance == null)
                _instance = this;
        }

        private void Start()
        {
            user = new User();
            var newMasterTable = Resources.Load<TextAsset>("MasterTable");
            masterTable = JsonMapper.ToObject<MasterTable>(newMasterTable.ToString());
            GameStart();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                Time.timeScale *= 2;
                print($"Time Scale : {Time.timeScale}");
            }
            else if(Input.GetKeyDown(KeyCode.Minus))
            {
                Time.timeScale /= 2;
                print($"Time Scale : {Time.timeScale}");
            }
        }

        public void GameStart()
        {
            stage.StageStart(new Stage(masterTable.MasterStages[stageLevel]));
        }

        public void EnemyKill(EnemyView enemy)
        {
            KillCount++;
            stage.EnemyDie(enemy);
            if (KillCount == 10)
            {
                KillCount = 0;
                user.Gold += 5;
                stageUI.UpdateGold(user.Gold);
            }
            stageUI.UpdateKillCount(KillCount);
        }

        public void StageEnd()
        {
            if (user.Hp > 0)
            {
                stageLevel++;
                stage.StageStart(new Stage(masterTable.MasterStages[stageLevel]));
            }
            else
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            print("GameOver");
        }
    }
}
 