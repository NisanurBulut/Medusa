using FluentValidation;
using Medusa.DataTransferObject;

namespace Medusa.Business.ValidationRules
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(a => a.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("Kategori Id 0'dan büyük olmalıdır");
            RuleFor(a => a.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("blog Id 0'dan büyük olmalıdır");
        }
    }
}
