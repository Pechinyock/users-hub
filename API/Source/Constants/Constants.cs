namespace TaskTrain.UserHub;

public sealed class Constants
{
    public sealed class Storage 
    {
        public const string STORAGE_NAME = "user_hub";

        public static readonly string STORAGE_PROVIDER_NAME = "Postgres";

        public static readonly string MIGRATIONS_HOME_PATH = Path.Combine(AppContext.BaseDirectory, $"{STORAGE_PROVIDER_NAME}Migrations");
    }
}
