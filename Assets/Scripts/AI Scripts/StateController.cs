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
    [SerializeField] public bool isZombie; 
    [SerializeField] NavMeshAgent _agent;

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

    // Start is called before the first frame update
    void Start()
    {
        //AIVariables = GetComponent<AIVariables>();
        _agent.speed = AIVariables.moveSpeed;
        perception = GetComponentInChildren<Perception>();

        perception.setVisionRadius(AIVariables.visionRange);

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

        Attackable attackable = target.GetComponent<Attackable>();

        if(attackable == null) {
            print("attackable is null");
            return false;
        }

        

       if(attackable.attack(AIVariables.attackDamage)) {

           // target is destroyed
        //    if(AIVariables.infectionChance > 0) {

        //        if(Random.Range(0, 100) <= AIVariables.infectionChance) {

        //            ZombieTracker.Infect(target.transform, );

        //        }

        //    }

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

}
