namespace TaskTrain.UserHub;

public interface IUserHubService
{
    public Task CreateUserAsync(CreateUserModel createUserModel);
}
