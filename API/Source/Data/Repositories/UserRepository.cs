using Microsoft.Extensions.Options;
using Npgsql;
using Dapper;
using TaskTrain.Core;
using TaskTrain.Contracts;
using System.Linq.Expressions;

namespace TaskTrain.UserHub;

internal sealed class UserRepositoryOptions 
{
    public string ConnectionString { get; set; }
}

[DapperAot]
internal sealed class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    private readonly UserRepositoryOptions _configuration;

    public UserRepository(IOptions<UserRepositoryOptions> options)
    {
        _configuration = options?.Value;
        _connectionString = _configuration.ConnectionString;
        _connectionString = "Host=localhost;Port=7777;Database=user_hub;Username=admin;Password=admin";
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public InsertionStatusEnum Insert(User entity)
    {
        try
        {
            var connection = new NpgsqlConnection(_connectionString);
            var createdUser = connection.QuerySingle<User>("insert into \"user-hub\".\"users\"" +
                " values(@login, @password_hash)" +
                " returning id, login, password_hash"
                , new { entity.Login, entity.Password }
            );

            return InsertionStatusEnum.Success;
        }
        catch (PostgresException ex)
        {
            if (ex.SqlState == "23505") 
            {
                return InsertionStatusEnum.ConstraintViolation;
            }
            return InsertionStatusEnum.Failed;
        }
    }

    public async Task<InsertionStatusEnum> InsertAsync(User entity)
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var createdUser = await connection.QueryAsync("insert into \"user-hub\".\"users\"" +
                " values(@id, @login, @password)"
                , new { entity.Id, entity.Login, entity.Password }
            );

            return InsertionStatusEnum.Success;
        }
        catch (PostgresException ex)
        {
            if (ex.SqlState == "23505")
            {
                return InsertionStatusEnum.ConstraintViolation;
            }
            return InsertionStatusEnum.Failed;
        }
    }

    public UpdateStatusEnum Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateStatusEnum> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public DeletionStatusEnum Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
