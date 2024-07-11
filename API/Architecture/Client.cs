using API.Conceptuals.ObserverPattern;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace API.Models;

public class Client : AbstractSubject<Instance, Client>
{
    private Thread _thread;
    private readonly DockerClient _dockerClient;
    private readonly Dictionary<string, Instance> _instancesById;
    private readonly Dictionary<int, Instance> _instancesByPort;
    
    public Client(Uri uri)
    {
        _thread = new Thread(LaunchInstancesUpdate);
        _instancesById = new Dictionary<string, Instance>();
        _instancesByPort = new Dictionary<int, Instance>();
        _dockerClient = new DockerClientConfiguration(uri).CreateClient();
        _thread.Start();
    }
    
    public async Task CreateInstance(Instance instance)
    {
        ImagesCreateParameters imagesCreateParameters = new ImagesCreateParameters { FromImage = instance.GetConfiguration().GetImage() };
        await _dockerClient.Images.CreateImageAsync(imagesCreateParameters, null, new Progress<JSONMessage>( (message) => { Console.WriteLine(message.Status); }));
        
        lock (_instancesByPort)
        {
            int port = 4000;
            while (_instancesByPort.ContainsKey(port))
                port++;
            instance.SetPort(port);
            _instancesByPort.Add(instance.GetPort(), instance);
        }
        
        instance.SetId((await _dockerClient.Containers.CreateContainerAsync(instance.GetContainerParameters())).ID);
        AddObserver(instance);
        _instancesById.Add(instance.GetId(), instance);
        
        if (instance.GetId() is null)
            throw new Exception("Instance not created");
        await _dockerClient.Containers.StartContainerAsync(instance.GetId(), null);
    }
    
    public async Task DeleteInstance(string id)
    {
        Instance instance = _instancesById[id];
        await _dockerClient.Containers.StopContainerAsync(id, new ContainerStopParameters());
        await _dockerClient.Containers.RemoveContainerAsync(id, new ContainerRemoveParameters());
        
        RemoveObserver(instance);
        
        _instancesById.Remove(id);
        lock (_instancesByPort)
            _instancesByPort.Remove(instance.GetPort());
    }

    private void LaunchInstancesUpdate()
    {
        while (true)
        {
            NotifyObservers(this);
            Thread.Sleep(200);
        }
    }
    
    public DockerClient GetDockerClient() => _dockerClient;
}