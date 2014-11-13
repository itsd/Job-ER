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

    [RoutePrefix("api/User")]
    public class UserController : ApiController {
        private IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService.ScreamIfNull("userService");
        }

        [Route("login")]
        public SigninModel Get_Login() {

            _userService.Add(new User {
                Username = "Admin",
                Password = "Admin",
                Firstname = "Admin",
                Lastname = "Admin",
                Email = "Admin@jober.com"
            });

            return new SigninModel {
                Username = "username",
                Password = "password"
            };
        }
    }
}
