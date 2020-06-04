using Microsoft.AspNetCore.Identity;

namespace Student2.BL.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public const string ADMIN = "Admin";
        public const string EDITOR = "Editor";
        public const string REGULAR = "Regular";
    }
}
