namespace TaskTrain.UserHub;

internal interface IUserRepository
{
    Task CreateAsync(CreateUserModel user);
}
