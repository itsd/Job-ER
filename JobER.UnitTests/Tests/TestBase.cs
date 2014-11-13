using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.UnitTests.Tests {
    public class TestBase {
        protected T GetService<T>() {
            return Resolver.GetService<T>();
        }
    }
}
