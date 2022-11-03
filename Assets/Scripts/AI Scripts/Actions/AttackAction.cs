using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackAction")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {   
        if(controller.target == null) return;

        if(Vector3.Distance(controller.transform.position, controller.target.transform.position) <= controller.AIVariables.attackRange) {

            //todo add some actuall attacking
            controller.attack();

        } 
      
    }

}
