﻿namespace Me.UserHub;

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

        configBuilder.AddJsonFile($"Config/appsettings.{environmentName}.json");

        return configBuilder;
    }

}
