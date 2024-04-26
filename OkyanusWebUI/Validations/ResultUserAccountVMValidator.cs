using FluentValidation;
using OkyanusWebUI.Models.UserAccountVM;

namespace OkyanusWebUI.Validations
{
    public class ResultUserAccountVMValidator : AbstractValidator<ResultUserAccountVM>
    {
        public ResultUserAccountVMValidator()
        {
            RuleFor(x => x.UserFirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.UserPhoneNumber).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
        }
    }
}
