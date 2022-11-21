using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class UnitGrid : MonoBehaviour
    {
        public UnitBase basePrefabs;
        public List<UnitBase> createdUnitBases = new();

        [Header("===== Grid =====")] 
        public int xCount;
        public int yCount;
        public float xOffset, yOffset;
        public float xInterval, yInterval;
        

        private void Start()
        {
            for (var i = 0; i < yCount; i++)
            {
                for (var j = 0; j < xCount; j++)
                {
                    var unitBase = Instantiate(basePrefabs, transform, false);
                    unitBase.transform.position = new Vector2(
                        -(float)xCount / 2 + j + xOffset + xInterval * j, 
                        -(float)yCount / 2 + i + yOffset + yInterval * i);
                    createdUnitBases.Add(unitBase);
                } 
            }
        }
    }
}
