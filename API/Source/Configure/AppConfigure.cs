namespace TaskTrain.UserHub;

internal static class AppConfigure
{
    internal static IConfigurationBuilder LoadEnvironmentVariables(this IConfigurationBuilder configBuilder) 
    {
        configBuilder.AddEnvironmentVariables("DOTNET_");
        configBuilder.AddEnvironmentVariables("ASPNETCORE_");
        return configBuilder;
    }

    internal static IConfigurationBuilder LoadAppsettingsJson(this IConfigurationBuilder configBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (String.IsNullOrWhiteSpace(environmentName)) 
        {
            environmentName = Constants.EnvDefaults.ASP_DEFAULT_ENVIRONMENT_NAME;
        }

        configBuilder.AddJsonFile($"Config/appsettings.{environmentName}.json");

        return configBuilder;
    }

    internal static IConfigurationBuilder LoadStoragesettingsJson(this IConfigurationBuilder configBuilder, string storageTypeName) 
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (String.IsNullOrWhiteSpace(environmentName))
        {
            environmentName = Constants.EnvDefaults.ASP_DEFAULT_ENVIRONMENT_NAME;
        }

        configBuilder.AddJsonFile($"Config/storagesettings.{environmentName}.{storageTypeName}.json");

        return configBuilder;
    }

}
