using FluentValidation;
using OkyanusWebUI.Models.MyPhoneVM;

namespace OkyanusWebUI.Validations.Admin.MyPhone
{
    public class CreateMyPhoneVMValidator : AbstractValidator<CreateMyPhoneVM>
    {
        public CreateMyPhoneVMValidator()
        {
            RuleFor(x => x.PhoneName).NotNull().WithMessage("Telefon Türü Boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Telefon Numarası Boş geçilemez");
        }
    }
}
