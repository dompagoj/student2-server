using System.ComponentModel.DataAnnotations.Schema;

namespace Student2.BL.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public int? TutorId { get; set; }
        public Tutor? Tutor { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; } = null!;
    }
}
