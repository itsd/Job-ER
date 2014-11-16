using JobER.Configuration;
using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Home.Shared;
using JobER.API.Models.Job;

namespace JobER.API.Controllers {
    [RoutePrefix("job")]
    public class JobController : ApiController {

        private IUserService _userService;
        private ISessionService _sessionService;
        private IJobService _jobService;

        public JobController(IUserService userService, ISessionService sessionService, IJobService jobService) {
            _userService = userService.ScreamIfNull("userService");
            _sessionService = sessionService.ScreamIfNull("sessionService");
            _jobService = jobService.ScreamIfNull("jobService");
        }

        [Route(""), HttpGet]
        public IEnumerable<JobModel> Jobs() {
            var jobs = _jobService.GetAll();
            return jobs.Select(x => (JobModel)x);
        }

        [Route("{id:int}"), HttpGet]
        public JobModel Job(int id) {
            return _jobService.Fetch(id);
        }

        [Route("category/{id:int}"), HttpGet]
        public IEnumerable<JobModel> JobByCategory(int categoryId) {
            var jobs = _jobService.GetJobsByCategory(categoryId);
            return jobs.Select(x => (JobModel)x);
        }
    }
}
