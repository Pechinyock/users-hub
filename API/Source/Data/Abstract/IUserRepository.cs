using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

internal interface IUserRepository
{
    Task CreateAsync(CreateUserRequest user);
}
