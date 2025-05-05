namespace Me.UserHub;

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

    internal static IServiceCollection ConfigureCORS(this IServiceCollection services) 
    {
        /* [TODO] For every configuration has to be different! */
        /* AllowAll - for Development only */
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        return services;
    }
}
