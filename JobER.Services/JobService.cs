using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Services {
    public class JobService : IJobService {
        private IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository) {
            _jobRepository = jobRepository;
        }

        public Job Fetch(int id) {
            return _jobRepository.Fetch(id);
        }
    }
}
