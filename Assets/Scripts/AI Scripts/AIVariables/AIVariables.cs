using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

[CreateAssetMenu(menuName = "PluggableAI/AIVariables")]
public class AIVariables : ScriptableObject
{
    public float moveSpeed;
    public int health;
    public float attackRange;
    public float attackDamage;
    public float attackSpeed;
    public float visionRange;
    public float timeToCheckNewEnemy;

    public int infectionChance;


}
