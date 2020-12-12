using FluentValidation;
using Medusa.DataTransferObject;

namespace Medusa.Business.ValidationRules
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
        }
    }
}
