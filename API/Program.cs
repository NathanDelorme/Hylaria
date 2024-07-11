using API.Models;
using API.Models.Interfaces;
using ConfigurationBuilder = API.Models.Interfaces.ConfigurationBuilder;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        List<Uri> dockerUris = [new Uri("npipe://./pipe/docker_engine")];
        ClientManager clientManager = new ClientManager(dockerUris);
        
        Configuration configurationMinecraft = new ConfigurationBuilder()
            .SetImage("itzg/minecraft-server:latest")
            .AddEnvironmentVariable("EULA", "TRUE")
            .SetPort(25565)
            .SetMaxPlayers(10)
            .SetHasWhiteList(true)
            .SetHasResourcePack(true)
            .Build();
        Console.WriteLine("etape1");
        Instance instance;
        for(int i = 0; i < 1; i++)
        {
            instance = new Instance($"minecraft_{i}", configurationMinecraft);
            clientManager.CreateInstance(dockerUris[0], instance);
        }
        
        /*
        Configuration configurationMongo = new ConfigurationBuilder()
            .SetImage("mongo")
            .SetPort(27017)
            .SetMaxPlayers(10)
            .SetHasWhiteList(true)
            .SetHasResourcePack(true)
            .Build();
        for(int i = 0; i < 3; i++)
        {
            instance = new Instance($"mongo_{i}", configurationMongo);
            clientManager.CreateInstance(dockerUris[0], instance);
        }*/

        Console.ReadKey();
    }

    /*
    IHost builder = CreateHostBuilder(args).Build();
    Configure(builder);
    builder.Run();
     private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    private static void Configure(IHost host)
    {
        IApplicationBuilder app = host.Services.GetRequiredService<IApplicationBuilder>();

        if (host.Services.GetRequiredService<IHostEnvironment>().IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }*/
}