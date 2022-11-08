using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace GameAsset.Scripts.View
{
    public class Hero : MonoBehaviour
    {
        public EnemyView target;

        public float attackInterval;

        private void Start()
        {
            ActionStart();
        }

        public void ActionStart()
        {
            StartCoroutine(nameof(ActionRoutine));
        }

        public void ActionStop()
        {
            StopCoroutine(nameof(ActionRoutine));
            target = null;
        }

        public IEnumerator ActionRoutine()
        {
            while (true)
            {
                Aim();
                if (target != null)
                    Attack();

                yield return new WaitForSeconds(attackInterval);
            }
        }

        public void Aim()
        {
            if (target == null)
            {
                print("targeting...");
                var targets = Physics.OverlapSphere(transform.position, 2f, LayerMask.GetMask("Enemy"));
                if (targets != null)
                {
                    foreach (var t in targets)
                    {
                        target = t.gameObject.GetComponent<EnemyView>();
                    }
                }
            }
            else
            {
                print($"target! : {target.name}");
                if (!(Vector3.Distance(target.transform.position, transform.position) > 2)) return;
                target = null;
                print("target missing");
            }
        }

        public void Attack()
        {
            target.Damaged(1);
            if (target.origin.HP <= 0)
            {
                target = null;
            }
        }

    }
}
