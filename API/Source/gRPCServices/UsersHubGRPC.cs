using Grpc.Core;
using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

internal sealed class UsersHubGRPC : Contracts.UserHub.UserHubBase
{
    private readonly IUserHubService _userHubService;

    public UsersHubGRPC(IUserHubService userHubService)
    {
        _userHubService = userHubService;
    }

    public override async Task<CreateUserResponse> Create(CreateUserRequest request, ServerCallContext context)
    {
        var model = request.ToModel();

        await _userHubService.CreateUserAsync(model);
        var result = Task.FromResult(new CreateUserResponse()
        {
            Login = request.Login
        }).Result;

        return result;
    }
}