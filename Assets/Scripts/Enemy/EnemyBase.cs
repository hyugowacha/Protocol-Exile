using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("적 체력")]
    [SerializeField]
    protected float hp;

    [Header("적 이동속도")]
    [SerializeField]
    protected float moveSpeed;

    [Header("적 데이터")]
    [SerializeField]
    protected EnemyData enemyData;

    [Header("시야 범위")]
    [SerializeField]
    protected float sightRange;

    [Header("공격 범위")]
    [SerializeField]
    protected float attackRange;

    public virtual void Attack() { }

    public virtual void Die() { }
    
}
