using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName ="PluggableAI/Actions/FindEnemy")]
public class FindEnemy : Action
{
    public override void Act(StateController controller)
    {
        Vector3 position = controller.transform.position;
        List<GameObject> enemies = EnemyTree.instance.getNearbyObjects(position, controller.AIVariables.visionRange);

        float MinDistance = 0;

        GameObject closest = null;

        foreach(GameObject obj in enemies) {

            float distance = Vector3.Distance(position, obj.transform.position);

            if(closest == null || distance < MinDistance) {
                closest = obj;
                MinDistance = distance;
            }

        }

        if(closest != null) {
            controller.setTarget(closest);
        }
 
    }
    
}
