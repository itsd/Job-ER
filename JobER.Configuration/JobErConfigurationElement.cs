using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    public class JobErConfigurationElement : ConfigurationElement {

        [ConfigurationProperty("sendRegistrationEmail", IsKey = false, IsRequired = true)]
        public bool SendRegistrationEmail {
            get { return (bool)base["sendRegistrationEmail"]; }
            set { base["sendRegistrationEmail"] = value; }
        }

        [ConfigurationProperty("resetPasswordUrl", IsKey = false, IsRequired = true)]
        public string ResetPasswordUrl {
            get { return (string)base["resetPasswordUrl"]; }
            set { base["resetPasswordUrl"] = value; }
        }

        [ConfigurationProperty("company", IsKey = false, IsRequired = true)]
        public CompanyConfigurationElement Company {
            get { return (CompanyConfigurationElement)base["company"]; }
            set { base["company"] = value; }
        }
    }
}
