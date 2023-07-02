using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.ORM.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Services
{
    public class JsonWebToken
    {

        private readonly ISettings _settings;
        public JsonWebToken(ISettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_settings.JsonWebTokenKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ID", user.ID.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }
    }
}
