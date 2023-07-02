using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dietbox.ECommerce.WebAPI.Controllers
{

    [ApiController]
    [Route("users")] 
    [ApiExplorerSettings(GroupName = "Usuários")]
    public class UsersController : BaseController
    {

        public UsersController()
        {

        }

    }
}
