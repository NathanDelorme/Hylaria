using API.Models;

namespace API.Architecture.InstanceStates;

public class PausedState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle paused state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter paused state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit paused state");
    }
}