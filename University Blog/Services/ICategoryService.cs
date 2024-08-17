using University_Blog.Models;

namespace University_Blog.Services
{
    public interface ICategoryService
    {
        public Task<int> AddCategory(CategoryDTO model);
        public Task<List<CategoryDTO>> GetAllCategories();
        public Task<CategoryDTO> GetCategoryById(int id);
        public Task UpdateCategory(int id, CategoryDTO model);
        public Task DeleteCategory(int id);
        public Task<CategoryDTO> GetCategoryByName(string name);
    }
}
