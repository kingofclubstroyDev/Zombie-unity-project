using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    bool changedStateThisUpdate = false;
    public AIVariables AIVariables;
    [HideInInspector] float stateTimeElapsed;
    [SerializeField] State currentState;
    [SerializeField] List<Transition> generalTransitions;
    [SerializeField] List<Action> generalActions;
    [SerializeField] public bool isZombie; 
    [SerializeField] NavMeshAgent _agent;

    NavMeshPath pendingPath;
    private int framePathUpdated;
    private bool awaitingPath = false;
    public int framesPerPathUpdate = 1;

    private Perception perception;

    public NavMeshAgent agent {
        get {return _agent;}
    }
    [SerializeField] private GameObject _target;
    public GameObject target
    {
        get { return _target; }
    }

    private float timeTargetChosen;

    private float timeLastAttacked;

    private Attackable attackable;

    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //AIVariables = GetComponent<AIVariables>();
        _agent.speed = AIVariables.moveSpeed;
        perception = GetComponentInChildren<Perception>();

        perception.setVisionRadius(AIVariables.visionRange);
        pendingPath = new NavMeshPath();

        attackable = GetComponent<Attackable>();

        attackable.initialize(AIVariables.health);

        rigidBody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        changedStateThisUpdate = false;
        foreach(Transition transition in generalTransitions) {

            if(transition.CheckTransition(this)) {

                TransitionToState(transition.getState());
                break;

            }
        }

        foreach(Action action in generalActions) {

            action.Act(this);

        }

        currentState?.UpdateState(this);
        
    }

    private void OnDrawGizmos()
    {
        // if(currentState != null)
        // {
        //     //todo: Draw gizmos if we want them
        // }
    }

    public void TransitionToState(State nextState)
    {
        currentState = nextState;
        if (changedStateThisUpdate == false)
        {
            OnExitState();
            changedStateThisUpdate = true;
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    //This will be for some manager to add some state transitions
    public void addTransition(Transition transition, int index) {
        generalTransitions.Insert(index, transition);
    }

    public void removeTransition(Transition transition) {

        generalTransitions.Remove(transition);

    }

    private void setTarget(GameObject newTarget) {
        _target = newTarget;
        timeTargetChosen = Time.time;
        perception.disablePerception();
    }

    public bool checkNewTarget() {
        return (Time.time - timeTargetChosen >= AIVariables.timeToCheckNewEnemy);
    }

    public bool attack() {

        if(target == null) {
            print("target == null");
            return false;

        } 

        if(Time.fixedTime - timeLastAttacked < AIVariables.attackSpeed) {
            return false;
        }
        
        timeLastAttacked = Time.fixedTime;

        if(attackable == null) {
            print("attackable is null");
            return false;
        }

        //TODO: fix this
        Transform targetTransform = target.transform;
        Vector3 position = targetTransform.position;
        Quaternion quaternion = targetTransform.rotation;
        if(attackable.attack(AIVariables.attackDamage)) {

           // target is destroyed
           if(AIVariables.infectionChance > 0) {

               if(Random.Range(0, 100) <= AIVariables.infectionChance) {

                   Infection infection = GetComponent<Infection>();

                   if(infection != null) {

                       GameEvents.instance.UnitInfected(target.gameObject, infection.newZombie);
                       //infection.infect(position, quaternion);
                    }   

               } else {
                   Destroy(target.gameObject);
               }

            } else {
                Destroy(target.gameObject);
            }

       }
        
        
        
        return true;

    }



    public void getNearestTarget() {

        if(!perception.perceptionEnabled) {
            perception.enablePerception();
            return;
        }

        List<GameObject> objects = perception.objects;

        if(objects.Count == 0) return;

        Vector3 position = transform.position;

        float MinDistance = 0;

        GameObject closest = null;

        foreach(GameObject obj in objects) {

            if(obj == null) continue;

            float distance = Vector3.Distance(position, obj.transform.position);

            if(MinDistance == 0 || distance < MinDistance) {
                closest = obj;
                MinDistance = distance;
            }

        }

        if(closest == null) {

            return;
            
        }

        setTarget(closest);

    }

    public void moveTowardsTarget() {

        if(agent.pathPending) return;

        if(Time.frameCount - framePathUpdated > framesPerPathUpdate) {

            agent.CalculatePath(target.transform.position, pendingPath);
            framePathUpdated = Time.frameCount;
            awaitingPath = true;
        }

        if(awaitingPath) {
            agent.SetPath(pendingPath);
            awaitingPath = false;
        }

    }

    private void OnCollisionEnter(Collision other) {

        string tag = isZombie ? "Enemy" : "Zombie";

        if(other.gameObject.tag != tag) return;

        if(target != other.gameObject) {

            setTarget(other.gameObject);

        }

    }

    public void stopMoving() {

        if(agent.isStopped == false) {
            agent.isStopped = true;
        }

        if(rigidBody.velocity != Vector3.zero) {
            rigidBody.velocity = Vector3.zero;
        }

    }

    public void continueMoving() {
        agent.isStopped = false;
    }

    public float getTimeToAttack() {

        return Time.fixedTime - timeLastAttacked;

    }

}
