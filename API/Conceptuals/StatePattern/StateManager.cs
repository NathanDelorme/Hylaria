namespace API.Conceptuals.StatePattern;

public class StateManager<T>
{
    private AbstractState<T> _currentState;
    
    public StateManager(AbstractState<T> initialState)
    {
        _currentState = initialState;
        _currentState.Enter();
    }
    
    public void SetState(AbstractState<T> newState)
    {
        if (_currentState.GetType().Name == newState.GetType().Name)
            return;
        
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }
    
    public AbstractState<T> GetState()
    {
        return _currentState;
    }
}