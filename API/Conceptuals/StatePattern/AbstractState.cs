namespace API.Conceptuals.StatePattern;

public abstract class AbstractState<T> : IState
{
    public abstract void Handle();
    
    public abstract void Enter();

    public abstract void Exit();
}