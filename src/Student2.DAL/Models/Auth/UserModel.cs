using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using LoginModel.Models;
using Student2.BL.Entities;

namespace Student2.DAL.Models.Auth
{
    public class UserModel
    {
        [Required] public int Id { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public bool EmailConfirmed { get; set; }
        [Required] public int UniversityId { get; set; }
        [Required] public University University { get; set; }
        [Required] public UserRole[] Roles { get; set; }

        public UserModel(AppUser user, IList<string> roles)
        {
            Id = user.Id;
            UserName = user.UserName ?? string.Empty;
            Email = user.Email ?? string.Empty;
            EmailConfirmed = user.EmailConfirmed;
            UniversityId = user.UniversityId;
            University = user.University;
            Roles = roles.Select(Enum.Parse<UserRole>).ToArray();
        }
    }
}
