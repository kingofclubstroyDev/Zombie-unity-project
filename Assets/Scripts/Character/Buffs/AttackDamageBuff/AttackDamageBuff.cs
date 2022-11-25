using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Buffs/AttackDamageBuff")]
public class AttackDamageBuff : Buff
{
    [SerializeField] float attackDamagePercentBuff;
    public override void ApplyBuff(UnitStats stats, AIVariables baseStats) {

        stats.attackDamage += baseStats.attackDamage * (attackDamagePercentBuff/100);

    }
}
