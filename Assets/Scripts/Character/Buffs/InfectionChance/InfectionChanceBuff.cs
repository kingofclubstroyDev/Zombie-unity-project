using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Buffs/InfectionChanceBuff")]
public class InfectionChanceBuff : Buff
{
    [SerializeField] int infectionPercentBuff;
    public override void ApplyBuff(UnitStats stats, AIVariables baseStats)
    {   
        
        stats.infectionChance += baseStats.infectionChance * (infectionPercentBuff / 100);
      
    }

}
