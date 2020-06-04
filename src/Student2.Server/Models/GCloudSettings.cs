using System.Text.Json.Serialization;

namespace Student2.Server.Models
{
    public class GCloudSettings
    {
        public string ApplicationCredentials { get; set; } = null!;

        public string ProjectId { get; set; } = null!;
    }
}
