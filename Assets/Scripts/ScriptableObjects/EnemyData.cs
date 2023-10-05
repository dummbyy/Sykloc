using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public int damage;
    public float health;
    public float moveSpeed;
}