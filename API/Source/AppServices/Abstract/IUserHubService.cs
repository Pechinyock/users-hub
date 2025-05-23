using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

public interface IUserHubService
{
    public Task CreateUserAsync(CreateUserRequest createUserModel);
}
