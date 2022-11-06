using System;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class Hero : MonoBehaviour
    {
        public Enemy target;
        private void Update()
        {
            if (target == null)
            {
                var targets = Physics.OverlapSphere(transform.position, 2f, LayerMask.GetMask("Enemy"));
                if (targets != null)
                {
                    
                }
            }
            else
            {
                
            }
        }
    }
}
