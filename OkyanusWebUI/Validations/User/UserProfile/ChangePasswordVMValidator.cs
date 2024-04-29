using FluentValidation;
using OkyanusWebUI.Models.UserAccountVM;

namespace OkyanusWebUI.Validations.User.UserProfile
{
    public class ChangePasswordVMValidator : AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordVMValidator()
        {
            RuleFor(x => x.CurrentPassword).NotNull().WithMessage("Mevcut Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.NewPassword).NotNull().WithMessage("Yeni Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmNewPassword).NotNull().WithMessage("Yeni Şifre Tekrar Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage("Yeni Şifre ve Yeni Şifre Tekrar alanları aynı olmalıdır.");
        }
    }
}
