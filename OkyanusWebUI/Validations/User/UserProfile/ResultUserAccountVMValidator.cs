using FluentValidation;
using OkyanusWebUI.Models.UserAccountVM;

namespace OkyanusWebUI.Validations.User.UserProfile
{
    public class ResultUserAccountVMValidator : AbstractValidator<ResultUserAccountVM>
    {
        public ResultUserAccountVMValidator()
        {
            RuleFor(x => x.UserFirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            //RuleFor(x => x.UserPhoneNumber).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
            RuleFor(item => item.UserPhoneNumber)
               .NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz!")
               .Matches(@"^05[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$")
               .WithMessage("Geçersiz telefon numarası formatı (05xx-xxx-xx-xx) şeklinde yazınız");
        }
    }
}
