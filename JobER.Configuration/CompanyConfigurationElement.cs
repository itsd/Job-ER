using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    public class CompanyConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("defaultImageUrl", IsKey = false, IsRequired = true)]
        public string DefaultImageUrl {
            get { return (string)base["defaultImageUrl"]; }
            set { base["defaultImageUrl"] = value; }
        }
    }
}
