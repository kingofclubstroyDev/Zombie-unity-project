using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/FindEnemy")]
public class FindEnemy : Action
{
    public override void Act(StateController controller)
    {
        
        controller.getNearestTarget();
 
    }
    
}
