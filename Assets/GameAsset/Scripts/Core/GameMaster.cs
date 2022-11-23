using System;
using System.Collections;
using GameAsset.Scripts.View;
using LitJson;
using UnityEngine;
using UnityEngine.Serialization;

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
        public UIManager uiManager;
        public int KillCount = 0;
        public int remainEnemy = 0;
        public float time = 0;
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
            
            StageStart();
        }
        
        public IEnumerator StartTime(float stageTime)
        {
            time = stageTime;
            UpdateTime();
            float sec = 0;
            while (true)
            {
                sec += Time.deltaTime;
                time -= Time.deltaTime;
                if (sec >= 1f)
                {
                    sec = 0;
                    UpdateTime();
                    if (time <= 0)
                    {
                        StageEnd();
                        yield break;
                    }
                }

                yield return null;
            }
        }

        private void UpdateTime()
        {
            uiManager.UpdateTime(time);
        }

        public void EnemyKill(EnemyView enemy)
        {
            KillCount++;
            stage.EnemyDie(enemy);
            if (KillCount == 10)
            {
                KillCount = 0;
                user.Gold += 5;
                uiManager.UpdateGold(user.Gold);
            }
            uiManager.UpdateKillCount(KillCount);
        }

        public void StageStart()
        {
            var newStage = new Stage(masterTable.MasterStages[stageLevel]);
            StartCoroutine(StartTime(newStage.Time));
            stage.StageStart(newStage);
        }
        public void StageEnd()
        {
            if (remainEnemy < 100)
            {
                stageLevel++;
                StageStart();
            }
            else
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            print("GameOver");
            StopAllCoroutines();
            stage.GameOver();
            uiManager.GameOver();
        }

        public void SpawnedEnemy()
        {
            ++remainEnemy;
            if (remainEnemy >= 100)
            {
                GameOver();
            }

            uiManager.UpdateRemainEnemy(remainEnemy);
        }

        public void EnemyDead()
        {
            uiManager.UpdateRemainEnemy(--remainEnemy);
        }
    }
}
 