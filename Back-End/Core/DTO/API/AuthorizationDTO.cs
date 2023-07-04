using Dietbox.ECommerce.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.DTO.API
{
    public class AuthorizationDTO
    {
        public AuthorizationDTO(string token, DateTime expiration, TenantType type)
        {
            Token = token;
            Expiration = expiration;
            Type = type;
        }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public TenantType Type { get; set; }
    }
}
