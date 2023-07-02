using Dietbox.ECommerce.Core.Commands.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Interfaces.Companies
{
    public interface ICompaniesHandler
    {

        /// <summary>
        /// Criar empresa.
        /// </summary>
        /// <param name="command">Comando de criação da empresa.</param>
        /// <returns></returns>
        Task Create(CreateCompanyCommand command);

    }
}
