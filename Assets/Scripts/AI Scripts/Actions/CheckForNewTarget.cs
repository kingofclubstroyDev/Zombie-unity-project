using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/CheckForNewTarget")]
public class CheckForNewTarget : Action
{
    public override void Act(StateController controller)
    {
       
       if(controller.checkNewTarget() == false) return;


        controller.getNearestTarget();
 
    }
    
}
