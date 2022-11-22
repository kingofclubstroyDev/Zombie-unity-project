using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/KiteTarget")]
public class KiteTarget : Action
{
    public override void Act(StateController controller)
    {

        if(controller.target == null) return;
        
        if(Vector3.Distance(controller.transform.position, controller.target.transform.position) < controller.AIVariables.attackRange) {

            float timeSinceLastAttack = controller.getTimeToAttack();

            float fifthAttackSpeed = controller.AIVariables.attackSpeed / 5;

            if(timeSinceLastAttack < fifthAttackSpeed || timeSinceLastAttack > (fifthAttackSpeed * 4)) {
                return;
            }

            Vector3 direction = (controller.target.transform.position - controller.transform.position).normalized;

            controller.rigidBody.AddForce(((Quaternion.Euler(0,180,0) * direction) * controller.AIVariables.moveSpeed / 20), ForceMode.Acceleration);

            
            return;

        }
 
    }
    
}
