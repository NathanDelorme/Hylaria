using API.Conceptuals.StatePattern;
using API.Models;

namespace API.Architecture.InstanceStates;

public class UnknownState : AbstractState<Instance>
{
    public override void Handle()
    {
        Console.WriteLine("Instance handle unknown state");
    }

    public override void Enter()
    {
        Console.WriteLine("Instance enter unknown state");
    }

    public override void Exit()
    {
        Console.WriteLine("Instance exit unknown state");
    }
}