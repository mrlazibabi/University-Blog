using University_Blog.Models;
using University_Blog.Repositories.Implement;

namespace University_Blog.Services.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> AddCategory(CategoryDTO model)
        {
            return await _categoryRepository.AddCategory(model);
        }

        public Task DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }

        public Task<List<CategoryDTO>> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Task<CategoryDTO> GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public Task<CategoryDTO> GetCategoryByName(string name)
        {
            return _categoryRepository.GetCategoryByName(name);
        }

        public Task UpdateCategory(int id, CategoryDTO model)
        {
            return _categoryRepository.UpdateCategory(id, model);
        }
    }
}
