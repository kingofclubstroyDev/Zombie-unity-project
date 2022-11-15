using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/MoveTowardsTarget")]
public class MoveTowardsTarget : Action
{
    public override void Act(StateController controller)
    {
        if(controller.agent.isActiveAndEnabled == false) return;
        if(controller.gameObject == null) return;
        if(controller.agent == null) return;

        bool isStopped = controller.agent.isStopped;
        if(controller.target == null) {

            if(!isStopped) {

                controller.agent.isStopped = true;
            }
            return;
        }

        if(Vector3.Distance(controller.transform.position, controller.target.transform.position) <= controller.AIVariables.attackRange) {

            //in range of attack, so lets stop moving
            if(isStopped) return;

            controller.agent.isStopped = true;

        }

        if(isStopped) {
            controller.agent.isStopped = false;
        }

        controller.moveTowardsTarget();
 
    }
    
}
