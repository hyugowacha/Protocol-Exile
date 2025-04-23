using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : EnemyBase
{
    IEnemyState enemyCurrentState;

    void Start()
    {
        hp = enemyData.hp;
        moveSpeed = enemyData.moveSpeed;
        sightRange = enemyData.sightRange;
        attackRange = enemyData.attackRange;
    }

    public void ChangeState(IEnemyState newstate)
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
