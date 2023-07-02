using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Settings
{
    public class DataBaseConfiguration
    {
        public string Source { get; set; }
        public string Catalog { get; set; }
        public bool Security { get; set; }
        public bool Encrypt { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int TimeOut { get; set; }
        public string ConnectionString
        {
            get
            {
                return string.Format(
                    $"Server={Source}; Database={Catalog}; Encrypt=False; Trusted_Connection=True;",
                    string.IsNullOrEmpty(User) ? "" : $"User Id={User}; Password={Password};"
                );
            }
        }

    }
}
