using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    public Transform positionA;
    public Transform positionB;
    EnemyAController enemyA;

    float waitCoolTime = 4.0f;
    float waitElapsedTime;

    public void EnterState(EnemyBase enemy)
    {
        enemyA = (EnemyAController)enemy;
        enemyA.nowState = SoldierState.Patrol;

        enemyA.agent.SetDestination(enemyA.wayPoints[0].position);
    }

    public void UpdateState(EnemyBase enemy)
    {

    }

    public void FixedUpdateState(EnemyBase enemy)
    {

    }
}
