using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decider/NoEnemies")]
public class NoEnemies : Decider
{
    override public bool Decide(StateController stateController)
    {
        return stateController.target == null;
    }
    
}
