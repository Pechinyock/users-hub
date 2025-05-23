namespace TaskTrain.UserHub;

internal static class ServiceConfigure
{
    internal static IServiceCollection AddUserRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.Configure<UserRepositoryOptions>(options =>
        {
            options.ConnectionString = configuration[""];
        });
        return services;
    }
}
