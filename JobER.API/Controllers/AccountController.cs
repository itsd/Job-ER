using JobER.API.Models.Account;
using JobER.Domain.Exceptions;
using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Home.Shared;
using JobER.API.Models;
using JobER.Domain;
using JobER.Configuration;

namespace JobER.API.Controllers {
    [RoutePrefix("account")]
    public class AccountController : ApiController {

        private ISessionService _sessionService;
        private IUserService _userService;
        private JobErConfig _joberConfig;

        public AccountController(ISessionService sessionService, IUserService userService, JobErConfig joberConfig) {
            _sessionService = sessionService.ScreamIfNull("sessionService");
            _userService = userService.ScreamIfNull("userService");
            _joberConfig = joberConfig.ScreamIfNull("joberConfig");
        }

        [Route("signup"), HttpPost]
        public UserSessionModel Signup(UserSignupModel model) {
            try {
                var user = _userService.Register(model.Username, model.Password, model.Firstname, model.Lastname, model.Email);
                return _sessionService.Login(model.Username, model.Password);
            } catch (DuplicateEmailException) {
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            } catch (DuplicateUsernameException) {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            } catch (InvalidEmailException) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            } catch (InvalidPasswordException) {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [Route("login"), HttpPost]
        public UserSessionModel Login(LoginRequestModel model) {
            try {
                return _sessionService.Login(model.Username, model.Password);
            } catch (LoginFailedException) {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [Route("logout"), HttpPost]
        public HttpResponseMessage Logout() {
            _sessionService.Logout(JobErSession.Current.Token);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("xxx"), HttpGet]
        public UserSessionModel XXX() {

            string x1 = _joberConfig.Application.Jober.Company.DefaultImageUrl;
            bool x2 = _joberConfig.Application.Jober.SendRegistrationEmail;

            _joberConfig.Application.Jober.SendRegistrationEmail = false;

            return new UserSessionModel {
                ID = 1,
                Token = string.Format("{0:N}{1:N}", Guid.NewGuid(), Guid.NewGuid()),
                Username = "username"
            };
        }
    }
}