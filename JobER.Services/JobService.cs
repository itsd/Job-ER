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

        public IEnumerable<Job> GetAll() {
            return _jobRepository.GetAll().ToList();
        }

        public IEnumerable<Job> GetJobsByCompany(int companyId) {
            return _jobRepository.GetJobsByCompany(companyId).ToList();
        }

        public IEnumerable<Job> GetJobsByCategory(int categoryId) {
            return _jobRepository.GetJobsByCategory(categoryId).ToList();
        }

        public void Save(Job job) {
            //TODO: Implement Job save method
            throw new NotImplementedException();
        }
    }
}