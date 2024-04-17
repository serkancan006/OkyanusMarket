using FluentValidation;
using OkyanusWebUI.Models.ContactMessageVM;

namespace OkyanusWebUI.Validations
{
    public class CreateContactMessageVMValidator : AbstractValidator<CreateContactMessageVM>
    {
        public CreateContactMessageVMValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen Adınızı boş geçmeyiniz");
            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen Mailinizi boş geçmeyiniz");
            RuleFor(x => x.Message).NotNull().WithMessage("Lütfen Mesajınızı boş geçmeyiniz");
        }
    }
}
