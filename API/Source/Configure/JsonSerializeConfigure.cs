using System.Text.Json.Serialization;
using TaskTrain.Contracts;

[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(CreateUserRequest))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}

internal static class JsonSerializeConfigure 
{
    internal static IServiceCollection ConfigureJsonSerializer(this IServiceCollection services) 
    {
        services.ConfigureHttpJsonOptions(options => 
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });
        return services;
    }
}