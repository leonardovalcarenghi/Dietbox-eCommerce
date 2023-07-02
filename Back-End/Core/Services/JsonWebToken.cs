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

        public string GenerateToken(Customer user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] buffer = Encoding.ASCII.GetBytes(_settings.JWT.Key);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ID", user.ID.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.JWT.HoursToExpire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(buffer), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;

        }
    }
}
