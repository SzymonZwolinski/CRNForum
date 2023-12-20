using Microsoft.Extensions.Configuration;

namespace Platender.Application.EF.Settings
{
    public class SqlConnectionSettings
    {
        public string DataSource { get; set; }
        public short Port { get; set; }
        public string Database { get; set; }

        public string BuildConnectionStrings()
        => $"Server={DataSource};Port={Port};Database={Database};";
    }
}
