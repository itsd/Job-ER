using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Home.Shared;
using JobER.API.Models.Account;

namespace JobER.API.Controllers {

    [RoutePrefix("api/User")]
    public class UserController : ApiController {
        private IUserService _userService;

        public UserController(IUserService userService) {
            //_userService = userService.ScreamIfNull("userService");
        }

        [Route("login")]
        public SigninModel Get_Login() {

            //_userService.Login("", "");

            return new SigninModel {
                Username = "username",
                Password = "password"
            };
        }
    }
}
