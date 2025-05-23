using TaskTrain.Core;

namespace TaskTrain.UserHub;

internal sealed class User : IEntity<Guid>
{
    public required Guid Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}
