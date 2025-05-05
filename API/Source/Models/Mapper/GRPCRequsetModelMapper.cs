using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

internal static class GRPCRequsetModelMapper
{
    public static CreateUserModel ToModel(this CreateUserRequest request) 
    {
        return new CreateUserModel()
        {
            Login = request.Login,
            Password = request.Password,
            RepeatPassword = request.RepeatPassword,
        };
    }
}
