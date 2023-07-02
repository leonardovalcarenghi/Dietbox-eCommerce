using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.DTO.Companies;
using Dietbox.ECommerce.Core.Exceptions;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Interfaces.Companies;
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

        public CompaniesHandler(
            IRepository<Company> repository,
            ICommandValidator validator
        )
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CompanyDTO> Create(CreateCompanyCommand command)
        {

            (bool isValid, List<string> messages) = await _validator.Validate<CreateCompanyValidator, CreateCompanyCommand>(command);
            if (isValid is false)
                throw new InvalidParameterException(messages.ToArray(), "Ocorreu um problema ao criar a empresa.");


            // converter command to entity:

            // salvar no banco:



            return new();
        }
    }
}
