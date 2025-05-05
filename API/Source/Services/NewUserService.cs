//using Grpc.Core;
//using Me.Contracts;

//namespace Me.UserHub;

//internal sealed class NewService : Contracts.UserHub.UserHubBase
//{
//    private readonly IUserRepository _userRepository;

//    public NewService(IUserRepository userRepository)
//    {
//        _userRepository = userRepository;
//    }

//    public override Task<CreateUserResponse> Create(CreateUserRequest request, ServerCallContext context)
//    {
//        var login = request.Login;
//        return Task.FromResult(new CreateUserResponse() { Login = login, IsSuccess = true });
//    }
//}