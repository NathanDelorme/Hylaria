using API.Conceptuals.StatePattern;

namespace API.Models;

public abstract class InstanceState : AbstractState<Instance>
{
    protected Instance Instance;

    protected InstanceState(Instance instance)
    {
        this.Instance = instance;
    }
}