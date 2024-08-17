using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_Blog.Data;
using University_Blog.Models;

namespace University_Blog.Repositories.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly UniversityBlogContext _DbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(UniversityBlogContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<int> AddCategory(CategoryDTO model)
        {
            var newCategory = _mapper.Map<Category>(model);
            _DbContext.Categories!.Add(newCategory);
            await _DbContext.SaveChangesAsync();

            return newCategory.CategoryId;
        }

        public async Task DeleteCategory(int id)
        {
            var deleteCategory = _DbContext.Categories!.SingleOrDefault(x => x.CategoryId == id);
            if (deleteCategory != null)
            {
                _DbContext.Categories!.Remove(deleteCategory);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var listCategories = await _DbContext.Categories!.ToListAsync();

            return _mapper.Map<List<CategoryDTO>>(listCategories);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _DbContext.Categories!.FindAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var category = await _DbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryName == name);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateCategory(int id, CategoryDTO model)
        {
            if (id == model.CategoryId)
            {
                var updateCategory = _mapper.Map<Category>(model);
                _DbContext.Categories!.Update(updateCategory);
                await _DbContext.SaveChangesAsync();
            }
        }
    }
}
