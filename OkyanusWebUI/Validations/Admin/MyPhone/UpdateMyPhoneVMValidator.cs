using FluentValidation;
using OkyanusWebUI.Models.MyPhoneVM;

namespace OkyanusWebUI.Validations.Admin.MyPhone
{
    public class UpdateMyPhoneVMValidator : AbstractValidator<UpdateMyPhoneVM>
    {
        public UpdateMyPhoneVMValidator()
        {
            RuleFor(x => x.PhoneName).NotNull().WithMessage("Telefon Türü Boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Telefon Numarası Boş geçilemez");
        }
    }
}
