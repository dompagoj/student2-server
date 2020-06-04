using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Student2.BL.Entities
{
    public class University : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Domain { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string IconUrl { get; set; } = null!;

        // TODO JsonIgnore is a hack, find a better way
        [JsonIgnore]
        public ICollection<AppUser> Users { get; set; } = null!;
    }
}
