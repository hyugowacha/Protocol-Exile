using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAController : EnemyBase
{
    private IEnemyState enemyCurrentState;
    public NavMeshAgent agent;
    public Transform[] wayPoints;

    public SoldierState nowState;

    void Start()
    {
        hp = enemyData.hp;
        moveSpeed = enemyData.moveSpeed;
        sightRange = enemyData.sightRange;
        attackRange = enemyData.attackRange;

        ChangeState(new PatrolState());
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

public enum SoldierState
{
    Wait, Patrol, Chase, EnterCombat, Combat, Return
}
