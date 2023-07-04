using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.DTO.Companies;
using Dietbox.ECommerce.Core.Exceptions;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Interfaces.Companies;
using Dietbox.ECommerce.Core.Mappers.Companies;
using Dietbox.ECommerce.Core.Validations.Companies;
using Dietbox.ECommerce.ORM.Entities.Companies;
using Dietbox.ECommerce.ORM.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Handlers.Companies
{
    public class CompaniesHandler : ICompaniesHandler
    {

        private readonly IRepository<Company> _repository;
        private readonly ICommandValidator _validator;
        private readonly CompanyMapperConfiguration _mapper;

        public CompaniesHandler(
            IRepository<Company> repository,
            ICommandValidator validator,
            CompanyMapperConfiguration mapper
        )
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task CreateAccount(CreateCompanyAccountCommand command)
        {
            (bool isValid, List<string> messages) = await _validator.Validate<CreateCompanyAccountValidator, CreateCompanyAccountCommand>(command);
            if (isValid is false)
                throw new InvalidParameterException(messages.ToArray());

            Company entity = _mapper.CreateMapper().Map<Company>(command);
            await _repository.Insert(entity);
        }
    }
}
