using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Configuration {
    public interface IConfigurationProvider {
        T GetConfigurationSection<T>(string sectionName) where T : ConfigurationSection;
        void SaveConfiguration();
    }
}
