using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Buffs/AttackSpeedBuff")]
public class AttackSpeedBuff : Buff
{
    [SerializeField] float attackSpeedPercentBuff;
    public override void ApplyBuff(UnitStats stats, AIVariables baseStats)
    {   
        
        if(attackSpeedPercentBuff >= 100) {
            Debug.LogError("Attack speed buff too high");
        }
        
        stats.attackSpeed -= baseStats.attackSpeed * (attackSpeedPercentBuff / 100);

        if(stats.attackSpeed <= 0) {
            Debug.LogError("Attack speed reduced too <= 0");
        }
      
    }

}
