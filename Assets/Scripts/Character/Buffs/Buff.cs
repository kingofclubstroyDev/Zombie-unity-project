using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : ScriptableObject
{
    public abstract void ApplyBuff(UnitStats stats, AIVariables baseStats);
}
