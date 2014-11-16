using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Services {
    public interface IJobService {
        Job Fetch(int id);
        void Save(Job job);
        IEnumerable<Job> GetJobsByCategory(int categoryId);
        IEnumerable<Job> GetAll();
        IEnumerable<Job> GetJobsByCompany(int companyId);
    }
}
