using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using JobER.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Repositories {
    public class UserRepository : IUserRepository {
        private EntityContext _entityContext;

        public UserRepository(EntityContext entityContext) {
            _entityContext = entityContext;
        }

        public User Fetch(int id) {
            return _entityContext.Users.FirstOrDefault(x => x.ID == id);
        }

        public void Add(User user) {
            _entityContext.Users.Add(user);
            _entityContext.Commit();
        }

        public User Get(int id) {
            return _entityContext.Users.FirstOrDefault(x => x.ID == id);
        }
    }
}
