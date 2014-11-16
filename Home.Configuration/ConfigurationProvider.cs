using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Configuration {
    public class ConfigurationProvider : IConfigurationProvider {

        private System.Configuration.Configuration _config;

        public virtual T GetConfigurationSection<T>(string sectionName) where T : System.Configuration.ConfigurationSection {
            _config = ConfigurationManager.OpenExeConfiguration(string.Empty);
            return _config.GetSection(sectionName) as T;
        }

        public void SaveConfiguration() {
            _config.Save(ConfigurationSaveMode.Minimal, false);
        }
    }
}
