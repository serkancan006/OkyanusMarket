using FluentValidation;
using OkyanusWebUI.Models.ContactVM;

namespace OkyanusWebUI.Validations.Admin.Contact
{
    public class UpdateContactVMValidator : AbstractValidator<UpdateContactVM>
    {
        public UpdateContactVMValidator()
        {
            RuleFor(x => x.Phone).NotNull().WithMessage("İletişim Telefon alanı boş geçilmez");
            RuleFor(x => x.Adres).NotNull().WithMessage("İletişim Adres alanı boş geçilmez");
            RuleFor(x => x.Title).NotNull().WithMessage("İletişim Başlık alanı boş geçilmez");
            RuleFor(x => x.Mail).NotNull().WithMessage("İletişim Mail alanı boş geçilmez");
            RuleFor(x => x.MapLocation).NotNull().WithMessage("İletişim Google Map IFrame source alanı boş geçilmez");
        }
    }
}
