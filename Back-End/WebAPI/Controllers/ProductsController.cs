using Dietbox.ECommerce.Core.Commands.Products;
using Dietbox.ECommerce.Core.Interfaces.Products;
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

        private readonly IProductsHandler _handler;
        private readonly IProductsQueries _queries;
        public ProductsController(IProductsHandler handler, IProductsQueries queries)
        {
            _handler = handler;
            _queries = queries;
        }

        /// <summary>
        /// [ EndPoint ] Buscar lista de produtos.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _queries.Get();
            return Ok(result);
        }

        /// <summary>
        /// [ EndPoint ] Buscar produto.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _queries.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// [ EndPoint ] Criar produto.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _handler.Create(command);
            return Ok(result, $"O produto '{command.Name}' foi criado com êxito.");
        }

        /// <summary>
        /// [ EndPoint ] Atualizar produto (não implementado).
        /// </summary>
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, object command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [ EndPoint ] Excluir produto.
        /// </summary>
        [HttpDelete("{id:int}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

    }
}
