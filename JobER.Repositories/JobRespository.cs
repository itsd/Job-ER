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
    }
}
