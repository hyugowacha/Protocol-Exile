using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    public Transform positionA;
    public Transform positionB;
    EnemyAController enemyA;
    float nowSpeed;

    float waitCoolTime = 4.0f;

    int pointNum = 0;

    public void EnterState(EnemyBase enemy)
    {
        enemyA = (EnemyAController)enemy;
        enemyA.nowState = SoldierState.Patrol;
        enemyA.agent.stoppingDistance = 0.5f;

        enemyA.agent.SetDestination(enemyA.wayPoints[pointNum].position);

        enemy.StartCoroutine(Patrol());
    }

    public void UpdateState(EnemyBase enemy)
    {
        nowSpeed = enemyA.agent.velocity.magnitude;
        enemyA.enemyAnimator.SetFloat("IsMove",nowSpeed);
    }

    public void FixedUpdateState(EnemyBase enemy)
    {
        
    }

    IEnumerator Patrol()
    {
        while(true)
        {
            if (enemyA.isPlayerFind)
            {
                yield break;
            }

            if (!enemyA.agent.pathPending && enemyA.agent.remainingDistance < enemyA.agent.stoppingDistance &&
                enemyA.agent.velocity.sqrMagnitude < 0.01f)
            {
                enemyA.agent.isStopped = true;
                enemyA.enemyAnimator.SetFloat("IsMove", 0f);

                yield return new WaitForSeconds(waitCoolTime);

                pointNum = (pointNum + 1) % enemyA.wayPoints.Length;
                enemyA.agent.SetDestination(enemyA.wayPoints[pointNum].position);
                enemyA.agent.isStopped = false;      
            }

            yield return null;
        }
    }
}
