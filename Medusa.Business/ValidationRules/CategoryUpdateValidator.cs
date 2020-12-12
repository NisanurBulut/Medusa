using FluentValidation;
using Medusa.DataTransferObject;

namespace Medusa.Business.ValidationRules
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(a => a.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id 0'dan büyük olmalıdır");
            RuleFor(a => a.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
        }
    }
}
