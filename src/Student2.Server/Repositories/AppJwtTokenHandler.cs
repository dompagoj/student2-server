using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Student2.Server.Models;

namespace Student2.Server.Repositories
{
    public class AppJwtTokenHandler
    {
        readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
        readonly JwtSettings _jwtSettings;
        readonly SigningCredentials _credentials;

        public AppJwtTokenHandler(IOptions<JwtSettings> settings)
        {
            _jwtSettings = settings.Value;
            _credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Value.Secret)), SecurityAlgorithms.HmacSha256);
        }

        public string CreateSignedToken(string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.Email, "email"),
                new Claim(ClaimTypes.Role, role)
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = _credentials,
                Issuer = _jwtSettings.Issuer,
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
