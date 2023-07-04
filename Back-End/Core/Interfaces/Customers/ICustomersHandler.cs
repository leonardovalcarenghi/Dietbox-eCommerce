using Dietbox.ECommerce.Core.Commands.Companies;
using Dietbox.ECommerce.Core.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Interfaces.Customers
{
    public interface ICustomersHandler
    {

        /// <summary>
        /// Criar conta de cliente.
        /// </summary>
        /// <param name="command">Comando de criação do cliente.</param>
        Task CreateAccount(CreateCustomerAccountCommand command);

    }
}
