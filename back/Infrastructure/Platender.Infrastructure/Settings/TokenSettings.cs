namespace Platender.Infrastructure.Options
{
    public class TokenSettings
    {
        public const string CONFIG_NAME = "TokenOptions";
        public string SigningKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public bool ValidateSigningKey { get; set; }
    }
}
