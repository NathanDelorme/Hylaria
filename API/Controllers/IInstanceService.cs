using API.Models;

namespace API.Controllers;

public interface IInstanceService
{
    Instance GetInstanceById(string id);
    List<Instance> GetInstances();
    string CreateInstance(Instance instance);
    void DeleteInstance(string id);
    
}