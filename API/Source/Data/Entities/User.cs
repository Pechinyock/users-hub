namespace TaskTrain.UserHub;

internal sealed class User
{
    public required Guid Id { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
}
