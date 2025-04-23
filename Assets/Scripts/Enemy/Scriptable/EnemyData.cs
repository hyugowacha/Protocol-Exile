using UnityEngine;

[CreateAssetMenu(fileName ="NewEnemyData" , menuName = "Enemy Data" , order = 1)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float hp;
    public float moveSpeed;
    public float sightRange;
    public float attackRange;
}
