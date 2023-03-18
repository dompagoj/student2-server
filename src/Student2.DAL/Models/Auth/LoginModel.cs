using System;

namespace Student2.DAL.Models.Auth
{
    public class LoginModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [Obsolete("Used only by the framework")]
        public LoginModel() { }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
