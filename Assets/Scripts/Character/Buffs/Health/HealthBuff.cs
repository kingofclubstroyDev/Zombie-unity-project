using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Buffs/HealthBuff")]
public class HealthBuff : Buff
{
    [SerializeField] int healthPercentBuff;
    public override void ApplyBuff(UnitStats stats, AIVariables baseStats)
    {   
        
        stats.health += baseStats.health * (healthPercentBuff / 100);
      
    }

}
