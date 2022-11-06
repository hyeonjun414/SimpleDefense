using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private List<Transform> _wayPoints;
    private int _curWayIndex = 0;
    //private GameAsset.Scripts.Core.Enemy originEnemy;

    public void Move(List<Transform> wayPoints)
    {
        _wayPoints = wayPoints;
        _Move();
    }

    public void _Move()
    {
        var dir = (transform.position - _wayPoints[_curWayIndex].position).normalized;
        transform.DOMove(_wayPoints[_curWayIndex].position, 0.2f)
            .OnComplete(() =>
            {
                _curWayIndex++;
                if (_curWayIndex == _wayPoints.Count)
                {
                    _curWayIndex = 0;
                }

                _Move();
            });
    }
    
}
