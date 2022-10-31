using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decider/SeesEnemy")]
public class SeesEnemy : Decider
{
    override public bool Decide(StateController stateController)
    {
        return (stateController.target != null); 
    }
}
