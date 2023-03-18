using System;

namespace Student2.DAL.Models.Auth
{
    public class RegisterModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Username { get; set; } = null!;

        [Obsolete("Used only by the framework")]
        public RegisterModel() { }

        public RegisterModel(string email, string password, string? username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }

    public class AuthResponse
    {
        public required string Token { get; init; }
        public required UserModel User { get; init; }
    }
}
