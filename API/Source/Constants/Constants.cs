namespace TaskTrain.UserHub;

public sealed class Constants
{
    public sealed class EnvDefaults 
    {
        public const string ASP_DEFAULT_ENVIRONMENT_NAME = "Production";
    }

    public sealed class Storage 
    {
        public static readonly string STORAGE_PROVIDER_NAME = "Postgres";
        public static readonly string MIGRATIONS_HOME_PATH = Path.Combine(AppContext.BaseDirectory, $"{STORAGE_PROVIDER_NAME}Migrations");
    }
}
