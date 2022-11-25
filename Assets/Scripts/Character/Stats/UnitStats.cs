using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStats
{
    AIVariables baseStats;

    public float moveSpeed;
    public int health;
    public float attackRange;
    public float attackDamage;
    public float attackSpeed;
    public float visionRange;
    public float timeToCheckNewEnemy;

    public int infectionChance;

   public UnitStats(AIVariables _baseStats, Buff[] buffs) {

        baseStats = _baseStats;

        moveSpeed = _baseStats.moveSpeed;

        attackSpeed = _baseStats.attackSpeed;

        health = _baseStats.health;
        attackRange = _baseStats.attackRange;
        attackDamage = _baseStats.attackDamage;
        visionRange = _baseStats.visionRange;
        timeToCheckNewEnemy = _baseStats.timeToCheckNewEnemy;
        infectionChance = _baseStats.infectionChance;

        foreach(Buff buff in buffs) {

            buff.ApplyBuff(this, _baseStats);

        }

    }

}
