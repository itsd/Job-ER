using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    [Serializable]
    public class ApplicationConfig : ConfigurationSection {
        [ConfigurationProperty("jober", IsRequired = false)]
        public JobErConfigurationElement Jober {
            get { return (JobErConfigurationElement)base["jober"]; }
            set { base["jober"] = value; }
        }
    }
}
