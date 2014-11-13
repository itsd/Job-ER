using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Shared {
    public interface IRepository<T> where T : class, new() {
        IUnitOfWork Context { get; }

        T Fetch(object id);
        IEnumerable<T> Find(params object[] ids);

        void Save(T entity);
        void Delete(T entity);
    }
}
