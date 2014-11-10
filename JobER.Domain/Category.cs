using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain {
    public class Category {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
