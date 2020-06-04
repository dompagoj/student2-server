using System;

namespace Student2.Server.Models.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [Obsolete("Used only by the framework")]
        public LoginDto() { }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}