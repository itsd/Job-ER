using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain {
    public class Job {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public Company Company { get; set; }
        public Category Category { get; set; }
    }
}
