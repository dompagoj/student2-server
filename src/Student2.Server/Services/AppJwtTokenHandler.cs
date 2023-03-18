using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Student2.BL.Entities;
using Student2.Server.Models;

namespace Student2.Server.Services
{
    public class AppJwtTokenHandler
    {
        readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
        readonly JwtSettings _jwtSettings;
        readonly SigningCredentials _credentials;

        public AppJwtTokenHandler(IOptions<JwtSettings> settings)
        {
            _jwtSettings = settings.Value;
            _credentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Value.Secret)),
                    SecurityAlgorithms.HmacSha256);
        }

        public string CreateSignedToken(AppUser user, string role, int? universityId = null)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.NormalizedUserName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.NormalizedEmail ?? string.Empty),
                new Claim(ClaimTypes.Role, role),
                new Claim("university", universityId?.ToString() ?? user.UniversityId.ToString()),
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = _credentials,
                Issuer = _jwtSettings.Issuer
            };

            return _handler.WriteToken(_handler.CreateToken(descriptor));
        }

        [Obsolete("Not implemented")]
        public string CreateEncryptedToken()
        {
            throw new NotImplementedException();
        }
    }
}
