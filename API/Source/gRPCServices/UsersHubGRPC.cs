using Grpc.Core;
using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

internal sealed class UsersHubGRPC : Contracts.UserHub.UserHubBase
{
    private readonly IUserRepository _usersRepository;

    public UsersHubGRPC(IUserRepository userRepository)
    {
        _usersRepository = userRepository;
    }

    public override async Task<CreateUserResponse> Create(CreateUserRequest request, ServerCallContext context)
    {
        await _usersRepository.InsertAsync(new User() {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password
        });
        var result = Task.FromResult(new CreateUserResponse()
        {
            Login = request.Login
        }).Result;
        return result;
    }
}