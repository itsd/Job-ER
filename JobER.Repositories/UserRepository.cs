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


    }
}
