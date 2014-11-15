using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    public class ApplicationConfig : ConfigurationSection {
        [ConfigurationProperty("company", IsRequired = false)]
        public CompanyConfigurationElement Company {
            get { return (CompanyConfigurationElement)base["company"]; }
            set { base["company"] = value; }
        }
    }
}
