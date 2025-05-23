namespace TaskTrain.UserHub;

internal static class EntryPoint
{
    internal static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder();

        /* [Note]
         * By default adds all environment variables
         * Clearing everything with Clear()
         * and adding the only ones we needed
         */
        builder.Configuration.Sources.Clear();
        builder.Configuration.LoadEnvironmentVariables();
        builder.Configuration.LoadAppsettingsJson();

        builder.WebHost.ConfigureServer();

        builder.Services.ConfigureJsonSerializer();
        builder.Services.AddGrpc();
        builder.Services.AddUserRepository(builder.Configuration);

        var app = builder.Build();

        app.MapGrpcService<UsersHubGRPC>();

        StorageInitializer.Initialize();

        app.Run();
    }
}