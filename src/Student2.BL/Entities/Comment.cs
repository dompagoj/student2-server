using System;
using System.Text.Json.Serialization;

namespace Student2.BL.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int UpVotes { get; set; } = 0;

        public int UserId { get; set; }
        public AppUser User { get; set; } = null!;
        public int PostId { get; set; }

        [JsonIgnore]
        public Post Post { get; set; } = null!;
    }
}
