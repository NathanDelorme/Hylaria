namespace API.Conceptuals.StatePattern;

public interface IState
{
    void Handle();
    void Enter();
    void Exit();
}