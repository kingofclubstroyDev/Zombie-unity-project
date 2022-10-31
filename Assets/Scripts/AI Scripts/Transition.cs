using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Transition")]
public class Transition : ScriptableObject
{
    [SerializeField] Decision decision;
    [SerializeField] State newState;
    public bool CheckTransition(StateController controller) {
        return decision.Decide(controller);
    }
    public State getState() {
        return newState;
    }
}
