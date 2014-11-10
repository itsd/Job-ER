using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Domain.Interfaces.Services {
    public interface ICategoryService {
        Category Fetch(int id);
        IEnumerable<Category> GetCategories();
    }
}
