using Dietbox.ECommerce.Core.Interfaces;
using Dietbox.ECommerce.Core.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;


namespace Dietbox.ECommerce.Core
{
    public class AppSettings : ISettings
    {

        public string CurrentDirectory { get; }
        public string CurrentBaseURL { get; }
        public string Environment { get; }
        public string ConnectionString { get; }
        public string JsonWebTokenKey { get; }

        public AppSettings(IConfiguration configuration)
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            CurrentBaseURL = null;
            Environment = configuration.GetSection("Environment").Value;
            ConnectionString = configuration.GetSection("ConnectionString").Value;
            JsonWebTokenKey = configuration.GetSection("JsonWebToken:Key").Value;
        }

        //public AppSettings(IHttpContextAccessor httpContext, IConfiguration configuration)
        //{
        //    CurrentDirectory = Directory.GetCurrentDirectory();
        //    CurrentBaseURL = $"https://{httpContext.HttpContext.Request.Host.Value}";
        //    Environment = configuration.GetSection("Environment").Value;
        //}

    }
}
