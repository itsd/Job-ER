using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobER.Domain;

namespace JobER.API.Models.Job {
    public class JobModel {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }

        public static implicit operator JobModel(JobER.Domain.Job Job) {
            return new JobModel {
                Name = Job.Name,
                CompanyName = Job.Company.Name,
                PublishDate = Job.PublishDate,
                EndDate = Job.EndDate
            };
        }
    }
}