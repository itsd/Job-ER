using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Repositories {
    public interface IUserRepository {
        User Fetch(int id);
        User Fetch(string username, string password);
        void Add(User user);
    }
}
