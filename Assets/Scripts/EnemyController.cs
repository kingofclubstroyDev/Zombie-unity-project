using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject target = null;

    [SerializeField] AIVariables aiVariables;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if(target == null) {
        //     findClosestTarget();
        // }

        

        // if(transform.position == target.transform.position) {

        //     Destroy(target);

        //     target = null;

        //     return;

        // }

        // transform.position = Vector3.Lerp(transform.position, target.transform.position, aiVariables.moveSpeed);

        // print(transform.position);
        
    }

    private void findClosestTarget() {

        List<GameObject> enemies = EnemyTree.instance.getNearbyObjects(transform.position, 40);

        float MinDistance = 0;

        GameObject closest = null;

        foreach(GameObject obj in enemies) {

            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if(closest == null || distance < MinDistance) {
                closest = obj;
                MinDistance = distance;
            }

        }

        print(closest);

        target = closest;

    }

    private void OnDestroy() {
        EnemyTracker.removeEnemy(gameObject);
    }
}
