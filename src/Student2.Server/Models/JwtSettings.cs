using System.Text.Json.Serialization;

namespace Student2.Server.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
    }

    // TODO not sure how to do this
    public class AppSecrets
    {
        [JsonPropertyName("GOOGLE_APPLICATION_CREDENTIALS")]
        public string GoogleApplicationCredentials { get; set; } = null!;
    }
}
