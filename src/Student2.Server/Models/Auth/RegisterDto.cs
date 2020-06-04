using System;

namespace Student2.Server.Models.Auth
{
    public class RegisterDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Username { get; set; } = null!;

        [Obsolete("Used only by the framework")]
        public RegisterDto() { }

        public RegisterDto(string email, string password, string? username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }
}