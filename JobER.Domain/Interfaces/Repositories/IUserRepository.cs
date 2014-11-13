using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Repositories {
    public interface IUserRepository {
        User Fetch(int id);
        void Add(User user);
        User Get(int id);
    }
}
