using TaskTrain.Core;
using TaskTrain.Core.Postgres;

namespace TaskTrain.UserHub;

internal static class Storage
{
    internal static IStorageUpdater ConfigureStorageUpdater(IConfiguration config) 
    {
        var postgresHost = config["PostgresDatabase:Host"];
        var postgresDbName = config["PostgresDatabase:DatabaseName"];
        var postgresPort = ushort.Parse(config["PostgresDatabase:Port"]);

        var pgConnection = new PostgreStorageConnection(host: postgresHost
            , port: postgresPort
            , databaseName: postgresDbName
            , userName: "postgres"
            , password: "123456"
        );

        var serviceHost = config["ServiceDatabase:Host"];
        var serviceDbName = config["ServiceDatabase:DatabaseName"];
        var serviceDbPort = ushort.Parse(config["ServiceDatabase:Port"]);

        var serviceConnection = new PostgreStorageConnection(host: serviceHost
            , port: serviceDbPort
            , databaseName: serviceDbName
            , userName: "admin"
            , password: "admin"
        );

        var options = new StorageUpdaterOptions();
        options.Connections = new Dictionary<string, IStorageConnection>()
        {
            { postgresDbName, pgConnection },
            { serviceDbName, serviceConnection }
        };

        /* [ISSUE] Should be calculated depends on storagesettings.*.*.json */
        options.MigrationsPorvider = new FileSystemMigrationProvider(Constants.Storage.MIGRATIONS_HOME_PATH);

        var storageUpdater = new PostgresDatabaseUpdater(options) as IStorageUpdater;
        return storageUpdater;
    }

    internal static void Update(IStorageUpdater updater) 
    {
        var lastVersion = updater.GetLastAvailableVersion();
        var currentVersion = updater.GetCurrentVersion();

        if (currentVersion < lastVersion)
            updater.Update(lastVersion);
    }
}
