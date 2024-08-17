using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Blog.Data;
using University_Blog.Models;
using University_Blog.Services;
using University_Blog.Services.Implement;

namespace University_Blog.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/api/category/get-all")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpGet("/api/category/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpGet("/api/category/search")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Please provide a title to search for");
            }

            try
            {
                var category = await _categoryService.GetCategoryByName(name);

                if (category == null)
                {
                    return NotFound("No posts found with that title");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPost("/api/category/add")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(CategoryDTO model)
        {
            try
            {
                // Validate the model using a validator
                //var validationResult = _validator.Validate(model);
                //if (!validationResult.IsValid)
                //{
                //    return BadRequest(validationResult.Errors);
                //}

                var newCategory = await _categoryService.AddCategory(model);
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("/api/category/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCateegory(int id, CategoryDTO model)
        {
            if (id != model.CategoryId)
            {
                return BadRequest("Id mismatch in request");
            }

            try
            {
                // Validate the model
                //var validationResult = _validator.Validate(model);
                //if (!validationResult.IsValid)
                //{
                //    return BadRequest(validationResult.Errors);
                //}

                await _categoryService.UpdateCategory(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpDelete("/api/category/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
