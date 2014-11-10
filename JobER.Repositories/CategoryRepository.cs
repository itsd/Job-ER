using JobER.Domain;
using JobER.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobER.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private ICategoryRepository _categoryRepository;

        public CategoryRepository(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public Category Fetch(int id) {
            return _categoryRepository.Fetch(id);
        }

        public IEnumerable<Category> GetCategories() {
            return _categoryRepository.GetCategories();
        }
    }
}
