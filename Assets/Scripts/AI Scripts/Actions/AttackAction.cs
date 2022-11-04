using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackAction")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {   
        if(controller.target == null) return;

        MonoBehaviour.print(controller.transform.position);

        MonoBehaviour.print("-----");
        MonoBehaviour.print(controller.target.transform.position);

        float distance = Vector3.Distance(controller.transform.position, controller.target.transform.position);
        

        MonoBehaviour.print("distance = " + distance);

        MonoBehaviour.print("attack range = " + controller.AIVariables.attackRange);

        if(distance <= controller.AIVariables.attackRange) {

            MonoBehaviour.print("attacking");
            //todo add some actuall attacking
            controller.attack();

        } 
      
    }

}
