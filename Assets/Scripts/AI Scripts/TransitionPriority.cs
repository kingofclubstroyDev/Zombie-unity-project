public struct TransitionPriority
{
    public int priority;
    public State newState;
    
    public TransitionPriority(int _priority, State _newState) {
        priority = _priority;
        newState = _newState;
    }
    
};
