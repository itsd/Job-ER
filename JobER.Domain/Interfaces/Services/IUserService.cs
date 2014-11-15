using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Services {
    public interface IUserService {
        JobErSession Login(string username, string password);
        void Save(User user);
        User Fetch(int id);
        User Register(string username, string password, string firstname, string lastname, string email);
    }
}
