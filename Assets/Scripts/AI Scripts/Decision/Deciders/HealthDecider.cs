using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decider/Health")]
public class HealthDecider : Decider
{

    [SerializeField]
    int minHealth;

    override public bool Decide(StateController stateController)
    {
        return true;
    }
    
}
