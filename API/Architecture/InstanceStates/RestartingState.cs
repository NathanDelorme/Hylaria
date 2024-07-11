using API.Models;

namespace API.Architecture.InstanceStates;

public class RestartingState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle restarting state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter restarting state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit restarting state");
    }
}