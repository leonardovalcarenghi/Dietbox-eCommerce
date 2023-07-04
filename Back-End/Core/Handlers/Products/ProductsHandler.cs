using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.Commands.Products;
using Dietbox.ECommerce.Core.DTO.Products;
using Dietbox.ECommerce.Core.Exceptions;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Interfaces.Products;
using Dietbox.ECommerce.Core.Mappers.Products;
using Dietbox.ECommerce.Core.Validations.Companies;
using Dietbox.ECommerce.Core.Validations.Products;
using Dietbox.ECommerce.ORM.Entities.Products;
using Dietbox.ECommerce.ORM.Interfaces;
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

        private readonly IRepository<Product> _repository;
        private readonly ICommandValidator _validator;
        private readonly ProductMapperConfiguration _mapper;

        public ProductsHandler(
            IRepository<Product> repository,
            ICommandValidator validator,
            ProductMapperConfiguration mapper
        )
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(CreateProductCommand command)
        {
            (bool isValid, List<string> messages) = await _validator.Validate<CreateProductValidator, CreateProductCommand>(command);
            if (isValid is false)
                throw new InvalidParameterException(messages.ToArray(), "Ocorreu um problema ao cadastrar o produto.");

            Product entity = _mapper.CreateMapper().Map<Product>(command);
            await _repository.Insert(entity);

            ProductDTO product = _mapper.CreateMapper().Map<ProductDTO>(entity);
            return product;
        }

        public Task Delete(DeleteProductCommand command)
        {
            throw new NotImplementedException();
        }


    }
}
