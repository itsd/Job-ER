using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Shared {
    public static class UtilExtenders {
        public static T ScreamIfNull<T>(this T obj, string name = null) where T : class {
            if (obj == null) throw new ArgumentNullException(name ?? typeof(T).Name);
            return obj;
        }
    }
}
