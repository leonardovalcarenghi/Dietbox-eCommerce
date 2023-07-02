using Dietbox.ECommerce.Core.Commands.Products;
using Dietbox.ECommerce.Core.Interfaces.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Handlers.Products
{
    public class ProductsHandler : IProductsHandler
    {

        private readonly DbContext _dbContext;

        public ProductsHandler()
        {
            
        }

        public Task Create(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DeleteProductCommand command)
        {
            throw new NotImplementedException();
        }


    }
}
