using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Repositories {
    public interface IJobRepository {
        Job Fetch(int id);
        IEnumerable<Job> GetAll();
        IEnumerable<Job> GetJobsByCategory(int categoryId);
        IEnumerable<Job> GetJobsByCompany(int companyId);
    }
}
