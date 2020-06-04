using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Student2.BL.Entities
{
    public class Tutor : BaseEntity
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
        public int UniversityId { get; set; }

        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = null!;

        public University University { get; set; } = null!;
    }
}
