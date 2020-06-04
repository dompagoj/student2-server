using System.ComponentModel.DataAnnotations;
using Student2.BL.Entities;

namespace Student2.DAL.Models
{
    public class TutorCreateModel
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }
    }

    public static class TutorExtensions
    {
        public static void Update(this Tutor tutor, TutorCreateModel form)
        {
            if (form.Firstname != null) tutor.Firstname = form.Firstname;
            if (form.Lastname != null) tutor.Lastname = form.Lastname;
            tutor.Email = form.Email;
        }
    }
}
