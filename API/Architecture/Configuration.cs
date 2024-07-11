namespace API.Models;

public class Configuration
{
    private string _image;
    private int _port;
    private int _maxPlayers;
    private bool _hasWhiteList;
    private bool _hasResourcePack;
    private List<Tuple<string, string>> _environmentVariables = new List<Tuple<string, string>>();

    public Configuration() { }
    
    public Configuration(string image, int port, int maxPlayers, bool hasWhiteList, bool hasResourcePack)
    {
        SetImage(image);
        SetPort(port);
        SetMaxPlayers(maxPlayers);
        SetHasWhiteList(hasWhiteList);
        SetHasResourcePack(hasResourcePack);
    }
    
    public List<Tuple<string, string>> GetEnvironmentVariables() => _environmentVariables;
    public void AddEnvironmentVariable(string key, string value)
    {
        if(string.IsNullOrEmpty(key))
            throw new ArgumentNullException("Key cannot be null or empty.");
        if(string.IsNullOrEmpty(value))
            throw new ArgumentNullException("Value cannot be null or empty.");
        _environmentVariables.Add(new Tuple<string, string>(key, value));
    }
    public string GetImage() => _image;
    public void SetImage(string image) => _image = image;
    public int GetPort() => _port;
    public void SetPort(int port)
    {
        if(port <= 0)
            throw new ArgumentOutOfRangeException($"Port must be greater than 0. Current value: {port}");
        _port = port;
    }
    
    public int GetMaxPlayers() => _maxPlayers;
    public void SetMaxPlayers(int maxPlayers)
    {
        if(maxPlayers <= 0 )
            throw new ArgumentOutOfRangeException($"Max players must be greater than 0. Current value: {maxPlayers}");
        _maxPlayers = maxPlayers;
    }
    
    public bool HasWhiteList() => _hasWhiteList;
    public void SetHasWhiteList(bool hasWhiteList) => _hasWhiteList = hasWhiteList;
    
    public bool HasResourcePack() => _hasResourcePack;
    public void SetHasResourcePack(bool hasResourcePack) => _hasResourcePack = hasResourcePack;
}