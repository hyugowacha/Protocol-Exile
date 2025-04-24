using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAController : EnemyBase
{
    private IEnemyState enemyCurrentState;
    public NavMeshAgent agent;

    void Start()
    {
        hp = enemyData.hp;
        moveSpeed = enemyData.moveSpeed;
        sightRange = enemyData.sightRange;
        attackRange = enemyData.attackRange;

        ChangeState(new WaitState());
    }

    public override void ChangeState(IEnemyState newstate)
    {
        enemyCurrentState = newstate;
        newstate.EnterState(this);
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Die()
    {
        base.Die();
    }

    void Update()
    {
        enemyCurrentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        enemyCurrentState.FixedUpdateState(this);
    }
}
