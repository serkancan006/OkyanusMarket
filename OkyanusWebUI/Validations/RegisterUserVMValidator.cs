using FluentValidation;
using OkyanusWebUI.Models.RegisterVM;

namespace OkyanusWebUI.Validations
{
    public class RegisterUserVMValidator : AbstractValidator<RegisterUserVM>
    {
        public RegisterUserVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez").EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            //RuleFor(item => item.PhoneNumber).NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz!");
            //.Matches(@"^05[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$")
            //.WithMessage("Geçersiz telefon numarası formatı (05xx-xxx-xx-xx) şeklinde yazınız");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifre ve Şifre Tekrar alanları aynı olmalıdır.");
        }
    }
}
