namespace API.Models.Interfaces;

public interface IConfigurationBuilder
{
    ConfigurationBuilder AddEnvironmentVariable(string key, string value);
    ConfigurationBuilder SetImage(string image);
    ConfigurationBuilder SetPort(int port);
    ConfigurationBuilder SetMaxPlayers(int maxPlayers);
    ConfigurationBuilder SetHasWhiteList(bool hasWhiteList);
    ConfigurationBuilder SetHasResourcePack(bool hasResourcePack);
}