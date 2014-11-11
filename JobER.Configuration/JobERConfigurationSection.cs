using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Configuration {
    [Serializable]
    public class JobERConfigurationSection : ConfigurationSection {
        //[ConfigurationProperty("watermark", IsRequired = false)]
        //public WatermarkConfigurationElement Watermark {
        //    get { return (WatermarkConfigurationElement)base["watermark"]; }
        //    set { base["watermark"] = value; }
        //}
    }
}
