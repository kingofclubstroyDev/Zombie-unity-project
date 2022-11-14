using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackAction")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {   
        if(controller.target == null) return;

        float distance = Vector3.Distance(controller.transform.position, controller.target.transform.position);

        if(distance <= controller.AIVariables.attackRange) {
            controller.attack();
        } 
      
    }

}
