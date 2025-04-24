using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : IEnemyState
{
    float waitCoolTime = 4.0f;
    float waitElapsedTime;

    public void EnterState(EnemyBase enemy)
    {

    }

    public void UpdateState(EnemyBase enemy)
    {
        waitElapsedTime += Time.deltaTime;

        if(waitElapsedTime > waitCoolTime)
        {
            //enemy.ChangeState(new PatrolState());
        }
    }

    public void FixedUpdateState(EnemyBase enemy)
    {

    }
}
