using JobER.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Shared;
using JobER.Repositories.Context;
using MongoDB.Driver.Builders;
using System.Threading;
using JobER.Domain;

namespace JobER.UnitTests.Tests {
    [TestClass]
    public class AccountTest : TestBase {

        private ISessionService _sessionService;
        private MongoContext _mongoContext;
        private IUserService _userService;

        public AccountTest() {
            _sessionService = Resolver.GetService<ISessionService>();
            _mongoContext = Resolver.GetService<MongoContext>();
            _userService = Resolver.GetService<IUserService>();
        }

        [TestMethod]
        public void Test_Register() {
            string username = "username";
            string password = "password";
            string firstname = "firstname";
            string lastname = "lastname";
            string email = "email@jober.com";

            var user = _userService.Register(username, password, firstname, lastname, email);

            Assert.IsTrue(user != null && user.ID > 0);
        }

        [TestMethod]
        public void Test_Login() {
            var session = _sessionService.Login("username", "password");

            Assert.IsNotNull(session);
            Assert.IsTrue(_mongoContext.Sessions.Count(Query.EQ("_id", session.Token)) > 0);

            Assert.AreEqual(session.Username, Thread.CurrentPrincipal.Identity.Name);
            Assert.IsTrue(Thread.CurrentPrincipal is JobErSession);
            Assert.AreSame(session, JobErSession.Current);
        }

        [TestMethod]
        public void Test_Logout() {

            var session = _sessionService.Login("username", "password");
            Assert.IsNotNull(session);
            Assert.IsTrue(_mongoContext.Sessions.Count(Query.EQ("_id", session.Token)) > 0);

            _sessionService.Logout(session.Token);
            Assert.IsTrue(_mongoContext.Sessions.Count(Query.EQ("_id", session.Token)) == 0);
        }
    }
}
