using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Student2.BL.Entities;
using LoginModel;

namespace Student2.Server.Extensions
{
    public static class IdentityExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequiredLength = 1;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.SignIn.RequireConfirmedEmail = true;
                opts.User.RequireUniqueEmail = true;
            });
        }
    }
}
