using Dietbox.ECommerce.Core.Commands.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Interfaces.Products
{
    public interface IProductsHandler
    {

        /// <summary>
        /// Criar produto.
        /// </summary>
        /// <param name="command">Comando de criação de produto.</param>
        /// <returns></returns>
        Task Create(CreateProductCommand command);


        /// <summary>
        /// Excluir produto.
        /// </summary>
        /// <param name="command">Comando de exclusão do produto.</param>
        /// <returns></returns>
        Task Delete(DeleteProductCommand command);
    }
}
