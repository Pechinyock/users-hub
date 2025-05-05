using TaskTrain.UserHub;
using System.Text.Json.Serialization;

[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(CreateUserModel))]
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