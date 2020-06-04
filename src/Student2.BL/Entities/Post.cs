using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student2.BL.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Content { get; set; }
        public string? ContentHtml { get; set; }

        public long UpVotes { get; set; } = 0;
        public DateTime CreatedAt { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; } = null!;

        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        public int CreatorId { get; set; }
        public AppUser Creator { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = null!;
    }
}
