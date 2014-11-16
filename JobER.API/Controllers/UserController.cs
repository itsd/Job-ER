using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Home.Shared;
using JobER.API.Models.Account;
using JobER.Domain;
using JobER.Configuration;
using JobER.API.Models.User;

namespace JobER.API.Controllers {

    [RoutePrefix("user")]
    public class UserController : ApiController {

        private IUserService _userService;
        private JobErConfig _joberConfig;

        public UserController(IUserService userService, JobErConfig joberConfig) {
            _userService = userService.ScreamIfNull("userService");
            _joberConfig = joberConfig.ScreamIfNull("joberConfig");
        }

        [Route("profile"), HttpGet]
        public UserModel Profile() {
            return _userService.Fetch(JobErSession.Current.UserID);
        }
    }
}