using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Repositories {
    public interface ICategoryRepository {
        Category Fetch(int id);
        IEnumerable<Category> GetCategories();
    }
}
