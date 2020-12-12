using FluentValidation;
using Medusa.DataTransferObject;

namespace Medusa.Business.ValidationRules
{
    public class AppUserValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola boş bırakılamaz");
        }
    }
}
