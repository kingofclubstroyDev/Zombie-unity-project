using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    GameObject target = null;
    [SerializeField] AIVariables aiVariables;
    Vector3 velocity = Vector3.zero;
    [SerializeField] NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent.speed = aiVariables.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        // if(target == null) {
        //     findClosestTarget();

        //     if(target == null) return;
        // }

        // if(Vector3.Distance(transform.position, target.transform.position) <= aiVariables.attackRange) {

        //     Destroy(target);

        //     target = null;

        //     agent.isStopped = true;

        //     return;

        // }

        // if(agent.isStopped) {
        //     agent.isStopped = false;
        // }
        // agent.destination = target.transform.position;
        
        
    }

    // private void findClosestTarget() {

    //     List<GameObject> enemies = EnemyTree.instance.getNearbyObjects(transform.position, 40);

    //     float MinDistance = 0;

    //     GameObject closest = null;

    //     foreach(GameObject obj in enemies) {

    //         float distance = Vector3.Distance(transform.position, obj.transform.position);

    //         if(closest == null || distance < MinDistance) {
    //             closest = obj;
    //             MinDistance = distance;
    //         }

    //     }

    //     target = closest;

    // }

    private void OnDestroy() {
        ZombieTracker.removeZombie(gameObject);
    }
}
