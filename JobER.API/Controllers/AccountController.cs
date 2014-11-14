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

namespace JobER.API.Controllers {
    [RoutePrefix("account")]
    public class AccountController : ApiController {

        private ISessionService _sessionService;

        public AccountController(ISessionService sessionService) {
            _sessionService = sessionService.ScreamIfNull("sessionService");
        }

        [Route("signup"), HttpPost]
        public UserSessionModel Signup() {
            //TODO: Implement Signup Method
            return new UserSessionModel { };
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
    }
}
