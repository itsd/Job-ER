using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain {
    public class User {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Company : User {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
