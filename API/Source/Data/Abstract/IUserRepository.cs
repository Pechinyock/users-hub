namespace Me.UserHub;

internal interface IUserRepository
{
    Task Create(CreateUserModel user);
}
