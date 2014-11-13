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

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> list, Action<T> action) {
            foreach (T x in list) action(x);
            return list;
        }
    }
}
