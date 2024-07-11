using API.Models;

namespace API.Architecture.InstanceStates;

public class NotCreatedState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle not created state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter not created state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit not created state");
    }
}