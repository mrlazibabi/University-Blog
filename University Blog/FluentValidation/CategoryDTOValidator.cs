using FluentValidation;
using University_Blog.Models;

namespace University_Blog.FluentValidation
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator()
        {
            RuleFor(x => x.CategoryName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Category name is required and cannot exceed 100 characters");
        }
    }
}
