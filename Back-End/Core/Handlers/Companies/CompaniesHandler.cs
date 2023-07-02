using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.Interfaces.Companies;
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

        public CompaniesHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateCompanyCommand command)
        {
            if (command is null)
                throw new Exception("Parâmetro inválido.");

            if (string.IsNullOrEmpty(command.Name) || string.IsNullOrWhiteSpace(command.Name))
                throw new Exception("Nome da empresa não informado.");

            if (command.Name.Length > 100)
                throw new Exception(string.Format("O campo 'Nome' não pode excer o limite de {0} caracteres", 100));

            if (string.IsNullOrEmpty(command.CNPJ) || string.IsNullOrWhiteSpace(command.CNPJ))
                throw new Exception("CNPJ da empresa não informado.");

            if (command.CNPJ.Length is not 14)
                throw new Exception("O campo 'CNPJ' contém 14 caracteres.");

            if (!command.CNPJ.All(char.IsDigit))
                throw new Exception("O campo 'CNPJ' está inválido.");

            bool existsCNPJ = await _repository.Get(_ => _.CNPJ == command.CNPJ).AnyAsync();
            if (existsCNPJ)
                throw new Exception("O CNPJ informado já possui cadastro.");

        }
    }
}
