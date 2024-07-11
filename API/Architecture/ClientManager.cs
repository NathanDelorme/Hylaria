namespace API.Models;

public class ClientManager
{
    private Dictionary<Uri, Client> _clients;

    public ClientManager(List<Uri> dockerUris)
    {
        _clients = new Dictionary<Uri, Client>();
        foreach (Uri uri in dockerUris)
            _clients.Add(uri, new Client(uri));
    }
    
    public void CreateInstance(Uri uri, Instance instance)
    {
        // Search for the best machine
        
        if(!_clients.ContainsKey(uri)) 
            throw new Exception("Client not found");
        _clients[uri].CreateInstance(instance);
    }
}