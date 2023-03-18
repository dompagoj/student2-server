using System.Security.Claims;

namespace LoginModel.Extensions
{
    public static class AuthExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            int.TryParse(userId, out var id);

            return id;
        }

        public static int GetUniversityId(this ClaimsPrincipal principal)
        {
            var universityId = principal.FindFirstValue("university");
            int.TryParse(universityId, out var id);

            return id;
        }

    }
}
