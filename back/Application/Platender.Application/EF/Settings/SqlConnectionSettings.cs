
namespace Platender.Application.EF.Settings
{
    public class SqlConnectionSettings
    {
        public const string CONFIG_NAME = "Sql";
        public string DataSource { get; set; }
        public short Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string BuildConnectionStrings()
        => $"server={DataSource}; Port={Port}; database={Database}; user={Username}; password={Password}";
    }
}
