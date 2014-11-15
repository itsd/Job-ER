using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    public class CompanyConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("username", IsKey = false, IsRequired = true)]
        public string Username {
            get { return (string)base["username"]; }
            set { base["username"] = value; }
        }

        [ConfigurationProperty("password", IsKey = false, IsRequired = true)]
        public string Password {
            get { return (string)base["password"]; }
            set { base["password"] = value; }
        }
    }
}
