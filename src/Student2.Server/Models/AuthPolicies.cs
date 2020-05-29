using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace Student2.Server.Models
{
    public class AuthPolicies
    {
        public const string ADMIN = "Admin";
        public const string EDITOR = "Editor";
        public const string REGULAR = "Regular";

        // Shouldn't be touched, simply add another policy above
        public static void RegisterPolicies(AuthorizationOptions opts)
        {
            opts.AddPolicy(ADMIN, builder => builder.RequireAuthenticatedUser().RequireRole(ADMIN).Build());
            opts.AddPolicy(EDITOR, builder => builder.RequireAuthenticatedUser().RequireRole(EDITOR, ADMIN).Build());
            opts.AddPolicy(REGULAR, builder => builder.RequireAuthenticatedUser().RequireRole(REGULAR, ADMIN).Build());
        }
    }
}
