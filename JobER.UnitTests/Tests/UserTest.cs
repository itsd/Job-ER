using JobER.Domain;
using JobER.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.UnitTests.Tests {
    [TestClass]
    public class UserTest : TestBase {

        [TestMethod]
        public void Test_GetUser() {
            int userId = 1;
            var service = Resolver.GetService<IUserService>();
            User user = service.Fetch(userId);

            Assert.IsTrue(user != null && user.ID == userId);
        }
    }
}
