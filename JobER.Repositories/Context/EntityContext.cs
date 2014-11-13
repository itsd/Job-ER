using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobER.Domain;
using Home.Entity;

namespace JobER.Repositories.Context {
    public class EntityContext : HomeEntityContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
