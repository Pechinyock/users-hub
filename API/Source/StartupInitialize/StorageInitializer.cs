using TaskTrain.Core;
using TaskTrain.Core.Postgres;

namespace TaskTrain.UserHub;

internal static class StorageInitializer
{
    internal static void Initialize()
    {
        var pgConnection = new PostgreStorageConnection(host: "localhost"
                , port: 7777
                , databaseName: "postgres"
                , userName: "postgres"
                , password: "123456"
            );

        var serviceConnection = new PostgreStorageConnection(host: "localhost"
                , port: 7777
                , databaseName: Constants.Storage.STORAGE_NAME
                , userName: "admin"
                , password: "admin"
            );
        var options = new StorageUpdaterOptions();
        options.Connections = new Dictionary<string, IStorageConnection>()
        {
                { "postgres" , pgConnection },
                { Constants.Storage.STORAGE_NAME, serviceConnection }
        };
        options.MigrationsPorvider = new FileSystemMigrationProvider(Constants.Storage.MIGRATIONS_HOME_PATH);

        var storageUpdater = new PostgresDatabaseUpdater(options) as IStorageUpdater;

        var lastVersion = storageUpdater.GetLastAvailableVersion();
        var currentVersion = storageUpdater.GetCurrentVersion();

        if (currentVersion < lastVersion)
            storageUpdater.Update(lastVersion);
    }
}
