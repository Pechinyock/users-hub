using TaskTrain.Core;

namespace TaskTrain.UserHub;

internal sealed class StorageUpdaterOptions
{
    public Dictionary<string, IStorageConnection> Connections { get; set; }
    public IMigrationsPorvider MigrationsPorvider { get; set; }
}

internal interface IStorageUpdater
{
    uint GetCurrentVersion();
    uint GetLastAvailableVersion();
    void Update(uint version);
}
