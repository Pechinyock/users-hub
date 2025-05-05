namespace Me.UserHub;

internal static class EntryPoint
{
    internal static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder();
        /* by defalul loads every single env var in to it */
        builder.Configuration.Sources.Clear();
        builder.Configuration.LoadEnvironmentVariables();
        builder.Configuration.LoadAppsettingsJson();

        builder.WebHost.ConfigureServer();

        builder.Services.ConfigureJsonSerializer();
        builder.Services.ConfigureCORS();

        builder.Services.AddGrpc();
        builder.Services.AddUserRepository(builder.Configuration);

        var app = builder.Build();
        
        app.UseCors("AllowAll");
        //app.MapGrpcService<NewService>();

        app.Run();
    }
}