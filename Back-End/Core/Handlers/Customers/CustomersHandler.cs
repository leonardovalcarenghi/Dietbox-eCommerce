using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.Commands.Users;
using Dietbox.ECommerce.Core.Exceptions;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Interfaces.Customers;
using Dietbox.ECommerce.Core.Mappers.Customers;
using Dietbox.ECommerce.Core.Validations.Companies;
using Dietbox.ECommerce.Core.Validations.Customers;
using Dietbox.ECommerce.ORM.Entities.Companies;
using Dietbox.ECommerce.ORM.Entities.Users;
using Dietbox.ECommerce.ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Handlers.Customers
{
    public class CustomersHandler : ICustomersHandler
    {

        private readonly IRepository<Customer> _repository;
        private readonly ICommandValidator _validator;
        private readonly CustomerMapperConfiguration _mapper;

        public CustomersHandler(
            IRepository<Customer> repository,
            ICommandValidator validator,
            CustomerMapperConfiguration mapper
        )
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task CreateAccount(CreateCustomerAccountCommand command)
        {
            (bool isValid, List<string> messages) = await _validator.Validate<CreateCustomerAccountValidator, CreateCustomerAccountCommand>(command);
            if (isValid is false)
                throw new InvalidParameterException(messages.ToArray());

            Customer entity = _mapper.CreateMapper().Map<Customer>(command);
            await _repository.Insert(entity);
        }
    }
}
