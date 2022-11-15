using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    private void Awake() {
        instance = this;
    }

    public event Action<GameObject> onUnitDeath;

    public void UnitDeath(GameObject obj) {

        if(onUnitDeath == null) return;

        onUnitDeath(obj);

    }
    
    public event Action<GameObject> onUnitAttackTarget;
    
    public void UnitAttackTarget(GameObject obj) {
    
        if(onUnitAttackTarget == null) return;
        
        onUnitAttackTarget(obj);
    }

}


