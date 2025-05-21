using Microsoft.Extensions.Options;

using TaskTrain.Core;
using TaskTrain.Core.Postgres;

namespace TaskTrain.UserHub;

internal sealed class PostgresDatabaseUpdater : IStorageUpdater
{
    private readonly PostgreStorageUpdater _updater;
    private readonly IMigrationsPorvider _migrationsPorvider;

    private const string PG_CONNECTION_KEY = "postgres";

    public PostgresDatabaseUpdater(StorageUpdaterOptions options)
    {
        if(options is null)
            throw new ArgumentNullException(nameof(options));

        _migrationsPorvider = options.MigrationsPorvider;

        if(_migrationsPorvider is null)
            throw new ArgumentNullException(nameof(options.MigrationsPorvider));

        var connections = options.Connections;
        if (connections is null)
            throw new ArgumentNullException(nameof(options.Connections));

        if (!connections.ContainsKey(PG_CONNECTION_KEY))
            throw new ArgumentException("Connections have to contain 'postgres' key with connection");

        if(!connections.ContainsKey(Constants.Storage.STORAGE_NAME))
            throw new ArgumentException($"Connections have to contain '{Constants.Storage.STORAGE_NAME}' key with connection");

        var pgConnection = connections[PG_CONNECTION_KEY];
        var serviceConnection = connections[Constants.Storage.STORAGE_NAME];

        _updater = new PostgreStorageUpdater(pgConnection, serviceConnection, _migrationsPorvider);
    }

    public uint GetCurrentVersion() => _updater.GetCurrentVersion();

    public uint GetLastAvailableVersion() => _migrationsPorvider.GetLastVersion();

    public void Update(uint version) => _updater.UpdateStorage(version);
}
