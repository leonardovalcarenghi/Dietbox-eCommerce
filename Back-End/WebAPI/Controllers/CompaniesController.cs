using Dietbox.ECommerce.Core.Commands.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dietbox.ECommerce.WebAPI.Controllers
{

    [ApiController]
    [Route("companies")]
    [ApiExplorerSettings(GroupName = "Empresas")]
    public class CompaniesController : BaseController
    {

        public CompaniesController()
        {

        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCompanyCommand command)
        {
            throw new NotImplementedException();
        }

    }
}
