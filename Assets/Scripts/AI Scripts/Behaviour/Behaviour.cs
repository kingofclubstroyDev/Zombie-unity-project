using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Behaviour")]
public class Behaviour : ScriptableObject
{
    public State currentState;
    public void DoTransitions(StateController stateController)
    {
        foreach (Transition transition in currentState.transitions)
        {
            if(transition.CheckTransition(stateController)) {

                currentState = transition.getState();
                
            }
        }
    }


}
