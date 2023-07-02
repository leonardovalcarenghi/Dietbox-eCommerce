using Dietbox.ECommerce.Core.Commands.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dietbox.ECommerce.WebAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("products")]
    [ApiExplorerSettings(GroupName = "Produtos")]
    public class ProductsController : BaseController
    {

        public ProductsController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, object command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

    }
}
