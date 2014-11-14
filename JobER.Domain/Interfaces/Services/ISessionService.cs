using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Services {
    public interface ISessionService {
        JobErSession Login(string username, string password);
        JobErSession ValidateToken(string token);
        void Logout(string token);
    }
}
