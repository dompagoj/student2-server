using Student2.BL.Entities;

namespace Student2.DAL.Models
{
    public class CourseCreateModel
    {
        public string Name { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public int? TutorId { get; set; }
    }

    public static class CourseExtensions
    {
        public static void Update(this Course course, CourseCreateModel form)
        {
            course.Name = form.Name;
            course.FullName = form.FullName;
            course.TutorId = form.TutorId;
        }
    }
}
