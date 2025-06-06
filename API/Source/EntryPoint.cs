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
        builder.Configuration.LoadStoragesettingsJson("Postgres");

        builder.WebHost.ConfigureServer();

        /* [ISSUE] Looks realy bad */
        var updater = Storage.ConfigureStorageUpdater(builder.Configuration);
        Storage.Update(updater);

        builder.Services.ConfigureJsonSerializer();
        builder.Services.AddGrpc();
        builder.Services.AddUserRepository(builder.Configuration);

        var app = builder.Build();

        app.MapGrpcService<UsersHubGRPC>();


        app.Run();
    }
}