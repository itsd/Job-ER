using JobER.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.UnitTests.Tests {
    [TestClass]
    public class AccountTest : TestBase {
        [TestMethod]
        public void Test_Register() {
            string username = "username";
            string password = "password";
            string firstname = "firstname";
            string lastname = "lastname";
            string email = "email@jober.com";

            var service = Resolver.GetService<IUserService>();
            var user = service.Register(username, password, firstname, lastname, email);

            Assert.IsTrue(user != null && user.ID > 0);
        }
    }
}
