namespace MyUserApp.Models
{
    public class UserDatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string Database { get; set; } = null!;

        public string Collection { get; set; } = null!;
    }
}