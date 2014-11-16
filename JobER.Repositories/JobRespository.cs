using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Repositories.Context {
    public class JobRespository : IJobRepository {
        private EntityContext _entityContext;

        public JobRespository(EntityContext entityContext) {
            _entityContext = entityContext;
        }

        public Job Fetch(int id) {
            return _entityContext.Jobs.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Job> GetJobsByCategory(int categoryId) {
            return _entityContext.Jobs.Where(x => x.Category.ID == categoryId);
        }

        public IEnumerable<Job> GetAll() {
            return _entityContext.Jobs.Where(x => x.IsActive);
        }

        public IEnumerable<Job> GetJobsByCompany(int companyId) {
            return _entityContext.Jobs.Where(x => x.IsActive && x.Company.ID == companyId);
        }
    }
}
