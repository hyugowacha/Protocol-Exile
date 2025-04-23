using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("�� ü��")]
    [SerializeField]
    protected float hp;

    [Header("�� �̵��ӵ�")]
    [SerializeField]
    protected float moveSpeed;

    [Header("�� ������")]
    [SerializeField]
    protected EnemyData enemyData;

    [Header("�þ� ����")]
    [SerializeField]
    protected float sightRange;

    [Header("���� ����")]
    [SerializeField]
    protected float attackRange;

    public virtual void Attack() { }

    public virtual void Die() { }
    
}
