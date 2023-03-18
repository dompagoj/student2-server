using Student2.BL.Entities;

namespace LoginModel.Models
{
    public class CourseCreateModel
    {
        public required string Name { get; init; }
        public required string FullName { get; init; }

        public int? TutorId { get; init; }
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
