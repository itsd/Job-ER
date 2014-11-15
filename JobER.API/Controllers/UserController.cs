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

namespace JobER.API.Controllers {

    [RoutePrefix("user")]
    public class UserController : ApiController {

        private IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService.ScreamIfNull("userService");
        }
    }
}