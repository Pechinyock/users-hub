namespace TaskTrain.UserHub;

internal sealed class UserHubService : IUserHubService
{
    private readonly IUserRepository _userRepository;

    public UserHubService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUserAsync(CreateUserModel request)
    {
        await _userRepository.CreateAsync(request);
    }
}
