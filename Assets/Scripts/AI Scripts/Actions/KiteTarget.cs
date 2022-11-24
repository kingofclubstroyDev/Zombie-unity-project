using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/KiteTarget")]
public class KiteTarget : Action
{
    public override void Act(StateController controller)
    {

        if(controller.target == null) return;
        
        //kite if the target is closer than 75% the max attack range
        if(Vector3.Distance(controller.transform.position, controller.target.transform.position) < controller.AIVariables.attackRange * 0.75) {

            float timeSinceLastAttack = controller.getTimeToAttack();

            float fifthAttackSpeed = controller.AIVariables.attackSpeed / 5;

            // don't move if the target is about to attack, or has jut recently attacked, to mimic attack prep, and after shot
            if(timeSinceLastAttack < fifthAttackSpeed || timeSinceLastAttack > (fifthAttackSpeed * 4)) {
                return;
            }

            Vector3 direction = (controller.target.transform.position - controller.transform.position).normalized;

            Vector3 newDirection = direction * controller.AIVariables.moveSpeed * Time.deltaTime;

            // move at half speed away when kiting
            Vector3 newPosition = controller.transform.position - (direction * ((controller.AIVariables.moveSpeed / 2) * Time.deltaTime));

            controller.transform.position = newPosition;
            
            return;

        }
 
    }
    
}
