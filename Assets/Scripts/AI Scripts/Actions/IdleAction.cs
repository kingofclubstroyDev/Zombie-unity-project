using UnityEngine;

[CreateAssetMenu (menuName ="PluggableAI/Actions/Idle")]
public class IdleAction : Action
{

    Vector2 newWayPoint;
    Vector3 wayPoint, oldWayPoint;
    float area;
    public float timeSmooth;
    private float time;
    

    public void Awake()
    {
        
    }

    void Start()
    {
        newWayPoint = Random.insideUnitCircle * area;
        //wayPoint = new Vector3(newWayPoint.x, transform.position.y, newWayPoint.y);
        //controller = GetComponent<CharacterController>();
        //oldWayPoint = wayPoint;
    }

    public override void Act(StateController controller)
    {
        
    }
}
