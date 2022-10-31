using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision")]
public class Decision : ScriptableObject
{
    //public abstract bool Decide(StateController controller);
    [SerializeField]
    public Decider[] deciders; 

    public bool Decide(StateController stateController)
    {
        foreach (Decider decider in deciders)
        {
            if(decider.Decide(stateController))
            {
                return true;
            }
           
        }

        return false;
    }

}
