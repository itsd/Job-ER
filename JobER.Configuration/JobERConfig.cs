using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Configuration;
using Home.Shared;

namespace JobER.Configuration {
    public class JobERConfig {
        private IConfigurationProvider _provider;
        public JobERConfig(IConfigurationProvider provider) {
            _provider = provider.ScreamIfNull("provider");
        }

        private static ApplicationConfig application = null;

        public ApplicationConfig Application {
            get {
                if (application == null) {
                    application = _provider.GetConfigurationSection<ApplicationConfig>("application");
                }
                return application;
            }
        }
    }
}
