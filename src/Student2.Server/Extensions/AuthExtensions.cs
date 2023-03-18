using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Student2.BL.Entities;
using Student2.Server.Models;

namespace Student2.Server.Extensions
{
    public static class AuthExtensions
    {
        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {

            var section = configuration.GetSection("JWT");
            services.Configure<JwtSettings>(section);
            var jwtSettings = section.Get<JwtSettings>() ?? throw new ("Failed to bind JWT Settings");

            services.AddAuthentication()
                .AddJwtBearer(opts =>
                {
                    opts.RequireHttpsMetadata = false;
                    opts.SaveToken = true;
                    opts.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            services.AddAuthorization(RegisterPolicies);
        }

        static void RegisterPolicies(AuthorizationOptions opts)
        {
            opts.AddPolicy(AppRole.ADMIN,
                builder => builder.RequireAuthenticatedUser().RequireRole(AppRole.ADMIN).Build());

            opts.AddPolicy(AppRole.EDITOR,
                builder => builder.RequireAuthenticatedUser().RequireRole(AppRole.EDITOR, AppRole.ADMIN).Build());

            opts.AddPolicy(AppRole.REGULAR,
                builder => builder.RequireAuthenticatedUser().RequireRole(AppRole.REGULAR, AppRole.ADMIN).Build());

            opts.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        }
    }
}
