using API.Models;

namespace API.Architecture.InstanceStates;

public class RunningState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle running state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter running state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit running state");
    }
}