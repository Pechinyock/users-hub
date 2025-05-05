namespace TaskTrain.UserHub;

public sealed class CreateUserModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
}
