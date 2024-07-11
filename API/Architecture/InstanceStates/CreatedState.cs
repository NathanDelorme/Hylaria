using API.Models;

namespace API.Architecture.InstanceStates;

public class CreatedState(Instance instance) : InstanceState(instance)
{
    public override void Handle()
    {
        Console.WriteLine($"{instance.GetName()} handle created state");
    }

    public override void Enter()
    {
        Console.WriteLine($"{instance.GetName()} enter created state");
    }

    public override void Exit()
    {
        Console.WriteLine($"{instance.GetName()} exit created state");
    }
}