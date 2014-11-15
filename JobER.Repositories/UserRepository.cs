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

        public User Fetch(string username, string password) {
            return _entityContext.Users.FirstOrDefault(x => x.Username == username && x.Password == password && !x.IsDeleted);
        }

        public void Save(User user) {
            _entityContext.Users.Add(user);
            _entityContext.Commit();
        }

        public bool EmailIsUnique(int userId, string email) {
            return !_entityContext.Users.Any(x => x.ID != userId && x.Email == email);
        }

        public bool UsernameIsUnique(int userId, string username) {
            return !_entityContext.Users.Any(x => x.ID != userId && x.Username == username);
        }
    }
}
