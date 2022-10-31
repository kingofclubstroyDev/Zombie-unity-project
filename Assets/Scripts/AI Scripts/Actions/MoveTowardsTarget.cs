using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/MoveTowardsTarget")]
public class MoveTowardsTarget : Action
{
    public override void Act(StateController controller)
    {
        bool isStopped = controller.agent.isStopped;
        if(controller.target == null) {
            if(isStopped) return;

            controller.agent.isStopped = true;
        }

        if(Vector3.Distance(controller.transform.position, controller.target.transform.position) <= controller.AIVariables.attackRange) {

            //in range of attack, so lets stop moving
            if(isStopped) return;

            controller.agent.isStopped = true;

        }

        if(isStopped) {
            controller.agent.isStopped = false;
        }
        
        controller.agent.destination = controller.target.transform.position;
 
    }
    
}
