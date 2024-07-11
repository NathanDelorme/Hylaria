using API.Models;

namespace API.Architecture.InstanceStates;

public class DeadState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle dead state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter dead state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit dead state");
    }
}