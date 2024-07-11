using API.Conceptuals.BuilderPattern;

namespace API.Models.Interfaces;

public class ConfigurationBuilder : AbstractBuilder<Configuration>, IConfigurationBuilder
{
    public override Configuration Build()
    {
        return _object;
    }

    public ConfigurationBuilder AddEnvironmentVariable(string key, string value)
    {
        _object.AddEnvironmentVariable(key, value);
        return this;
    }

    public ConfigurationBuilder SetImage(string image)
    {
        _object.SetImage(image);
        return this;
    }

    public ConfigurationBuilder SetPort(int port)
    {
        _object.SetPort(port);
        return this;
    }

    public ConfigurationBuilder SetMaxPlayers(int maxPlayers)
    {
        _object.SetMaxPlayers(maxPlayers);
        return this;
    }

    public ConfigurationBuilder SetHasWhiteList(bool hasWhiteList)
    {
        _object.SetHasWhiteList(hasWhiteList);
        return this;
    }

    public ConfigurationBuilder SetHasResourcePack(bool hasResourcePack)
    {
        _object.SetHasResourcePack(hasResourcePack);
        return this;
    }
}