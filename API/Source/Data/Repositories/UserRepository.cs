using Npgsql;
using Microsoft.Extensions.Options;
using TaskTrain.Contracts;

namespace TaskTrain.UserHub;

internal sealed class UserRepositoryOptions 
{
    public string ConnectionString { get; set; }
}

internal sealed class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    private readonly UserRepositoryOptions _configuration;

    public UserRepository(IOptions<UserRepositoryOptions> options)
    {
        _configuration = options?.Value;
        _connectionString = _configuration.ConnectionString;
    }

    public Task CreateAsync(CreateUserRequest user)
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        connection.Close();
        return Task.CompletedTask;
    }
}
