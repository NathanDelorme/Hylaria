using API.Models;

namespace API.Architecture.InstanceStates;

public class ExitedState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle exited state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter exited state");
        instance.GetClient().DeleteInstance(instance.GetId());
        Console.WriteLine($"{instance.GetName()} deleted");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit exited state");
    }
}