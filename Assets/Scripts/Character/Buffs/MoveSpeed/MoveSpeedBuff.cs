using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Buffs/MoveSpeedBuff")]
public class MoveSpeedBuff : Buff
{
    [SerializeField] float moveSpeedPercentBuff;
    public override void ApplyBuff(UnitStats stats, AIVariables baseStats) {

        stats.moveSpeed += baseStats.moveSpeed * (moveSpeedPercentBuff/100);

    }
}
