using API.Architecture.InstanceStates;
using API.Conceptuals.StatePattern;
using Docker.DotNet;
using ConceptualsObserver = API.Conceptuals.ObserverPattern;
using Docker.DotNet.Models;

namespace API.Models;

public class Instance : ConceptualsObserver.IObserver<Client>
{
    private Client? _client;
    private string? _id;
    private string _name;
    private int? _port;
    private Configuration _configuration;
    private StateManager<Instance> _stateManager;

    public Instance(string name, Configuration configuration)
    {
        _name = name;
        _configuration = configuration;
        _stateManager = new StateManager<Instance>(new NotCreatedState(this));
    }
    
    public Client GetClient() => _client ?? throw new Exception("Client not set");
    public void SetClient(Client client) => _client = _client is null ? client : throw new Exception("Client already set");
    public int GetPort() => _port ?? throw new Exception("Port not set");
    public void SetPort(int port) => _port = _port is null ? port : throw new Exception("Port already set");
    public string GetId() => _id ?? throw new Exception("Id not set");
    public void SetId(string id) => _id = _id is null ? id : throw new Exception("Id already set");
    public string GetName() => _name;
    public Configuration GetConfiguration() => _configuration;
    public CreateContainerParameters GetContainerParameters()
    {
        List<string> environnementVariable = new List<string>();

        foreach (Tuple<string, string> coupleEnvVar in GetConfiguration().GetEnvironmentVariables())
            environnementVariable.Add($"{coupleEnvVar.Item1}={coupleEnvVar.Item2}");
        
        return new CreateContainerParameters
        {
            Name = GetName(),
            Image = GetConfiguration().GetImage(),
            Env = environnementVariable,
            HostConfig = new HostConfig
            {
                PortBindings = new Dictionary<string, IList<PortBinding>>
                {
                    {
                        GetConfiguration().GetPort().ToString() + "/tcp", new List<PortBinding>
                        {
                            new PortBinding { HostPort = GetPort().ToString() }
                        }
                    }
                }
            }
        };
    }

    public void Update(Client client)
    {
        _client ??= client;
        ContainerInspectResponse response = GetClient().GetDockerClient().Containers.InspectContainerAsync(GetId()).Result;
        AbstractState<Instance> newState;
        
        switch (response.State.Status)
        {
            case "created":
                newState = new CreatedState(this);
                break;
            case "running":
                newState = new RunningState(this);
                break;
            case "restarting":
                newState = new RestartingState(this);
                break;
            case "exited":
                newState = new ExitedState(this);
                break;
            case "paused":
                newState = new PausedState(this);
                break;
            case "dead":
                newState = new DeadState(this);
                break;
            default:
                newState = new UnknownState();
                break;
        }
        _stateManager.SetState(newState);
    }
}