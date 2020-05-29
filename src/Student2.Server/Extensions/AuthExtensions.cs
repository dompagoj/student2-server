using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Student2.Server.Models;

namespace Student2.Server.Extensions
{
    public static class AuthExtensions
    {
        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("JWT");
            services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.RequireHttpsMetadata = false;
                    opts.SaveToken = true;
                    opts.TokenValidationParameters = new TokenValidationParameters()
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

            services.AddAuthorization(AuthPolicies.RegisterPolicies);
        }
    }
}
