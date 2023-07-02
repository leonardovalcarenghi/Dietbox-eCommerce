using Dietbox.ECommerce.Core;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Settings;
using Dietbox.ECommerce.WebAPI.Configurations.Services;

namespace Dietbox.ECommerce.WebAPI.Configurations
{
    public static class DependencyInjectionConfiguration
    {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            //services.Configure<DataBaseConfiguration>(configuration.GetSection("DataBase"));
            //services.Configure<JsonWebTokenConfiguration>(configuration.GetSection("JWT"));


            services.AddScoped<ISettings, AppSettings>();
            services.AddSwaggerConfiguration(configuration, environment);
            services.AddJwtConfiguration(configuration);


            services.RegisterServicesForORM(configuration);

          

            
        }

    }
}
