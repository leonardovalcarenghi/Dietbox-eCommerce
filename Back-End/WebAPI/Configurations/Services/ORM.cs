using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.ORM;
using Dietbox.ECommerce.ORM.Contexts;
using Dietbox.ECommerce.ORM.Entities.Companies;
using Dietbox.ECommerce.ORM.Entities.Products;
using Dietbox.ECommerce.ORM.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime;

namespace Dietbox.ECommerce.WebAPI.Configurations.Services
{

    public static class ORMConfigurations
    {
        public static void RegisterServicesForORM(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x => services.GetType().Assembly);
            services.UseBasicContextTo("Server=localhost\\SQLEXPRESS; Database=master; Trusted_Connection=True;");
            services.UseAllConfigurations();

            // Entidades:
            services.UseReposityTo<Company>();
            services.UseReposityTo<Customer>();
            services.UseReposityTo<Product>();

        }
    }

}
