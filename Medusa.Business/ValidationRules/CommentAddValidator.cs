using FluentValidation;
using Medusa.DataTransferObject;

namespace Medusa.Business.ValidationRules
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(a => a.AuthorEmail).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(a => a.AuthorName).NotEmpty().WithMessage("Parola boş bırakılamaz");
            RuleFor(a => a.Description).NotEmpty().WithMessage("Yorum alanı boş bırakılamaz");

        }
    }
}
