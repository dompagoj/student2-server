using System.Collections.Generic;
using Student2.BL.Entities;

namespace Student2.Server.Models.Auth
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public IList<string>? Roles { get; set; }

        public UserDto(int id, string userName, string email, bool emailConfirmed, int universityId, University university)
        {
            Id = id;
            UserName = userName;
            Email = email;
            EmailConfirmed = emailConfirmed;
            UniversityId = universityId;
            University = university;
        }

        public UserDto(AppUser user, IList<string> roles)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            EmailConfirmed = user.EmailConfirmed;
            UniversityId = user.UniversityId;
            University = user.University;
            Roles = roles;
        }
    }
}
