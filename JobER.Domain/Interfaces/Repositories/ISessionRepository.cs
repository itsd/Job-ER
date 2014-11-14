using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Repositories {
    public interface ISessionRepository {
        JobErSession Fetch(string token);
        void Save(JobErSession session);
        void Delete(string token);
        void UpdateLastAccess(string token);
    }
}
