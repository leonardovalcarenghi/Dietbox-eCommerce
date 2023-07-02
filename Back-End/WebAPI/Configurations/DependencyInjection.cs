﻿using Dietbox.ECommerce.Core;
using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Services;
using Dietbox.ECommerce.Core.Settings;
using Dietbox.ECommerce.Core.Validations;
using Dietbox.ECommerce.WebAPI.Configurations.Services;

namespace Dietbox.ECommerce.WebAPI.Configurations
{
    public static class DependencyInjectionConfiguration
    {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {    
                
            services.AddScoped<ICommandValidator, CommandValidator>();
            services.AddScoped<ISettings, AppSettings>();
            services.AddScoped<GoogleRecaptcha>();


            services.AddSwaggerConfiguration(configuration, environment);
            services.AddJwtConfiguration(configuration);




            services.RegisterServicesForORM(configuration);



            services.RegisterServicesForCompanies();





        }

    }
}
