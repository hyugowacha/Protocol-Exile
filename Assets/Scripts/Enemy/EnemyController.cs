using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAController : EnemyBase
{
    private IEnemyState enemyCurrentState;
    public NavMeshAgent agent;
    public Transform[] wayPoints;
    public Rigidbody enemyRigid;
    public Animator enemyAnimator;

    public Collider[] findColliders;
    public Collider[] attackColliders;

    public bool isPlayerFind;

    public SoldierState nowState;

    void Start()
    {
        hp = enemyData.hp;
        moveSpeed = enemyData.moveSpeed;
        sightRange = enemyData.sightRange;
        attackRange = enemyData.attackRange;
        isPlayerFind = false;

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
        findColliders = Physics.OverlapSphere(transform.position, sightRange);

        attackColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach(var hit in findColliders)
        {
            if (hit.CompareTag("Player"))
            {
                agent.isStopped = true;

                Debug.Log("적 발견");
                foreach(var hit2 in attackColliders)
                {
                    Debug.Log("공격 개시");
                }
                
            }
        }
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
