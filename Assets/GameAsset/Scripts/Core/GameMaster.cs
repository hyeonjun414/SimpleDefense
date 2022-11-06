using System;
using GameAsset.Scripts.View;
using LitJson;
using UnityEngine;

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

        public void GameStart()
        {
            stage.StageStart(new Stage(masterTable.MasterStages[stageLevel]));
        }
    }
}
