using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Services {
    public interface IUserService {
        void Login(string username, string password);
        void Add(User user);
        User Get(int id);
    }
}
