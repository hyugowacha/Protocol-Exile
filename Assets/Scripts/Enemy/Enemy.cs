using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    float hp;
    float moveSpeed;
    GameObject Weapon;
    EnemyData enemyData;

    public virtual void Attack() { }
    public virtual void Die() { }
}
