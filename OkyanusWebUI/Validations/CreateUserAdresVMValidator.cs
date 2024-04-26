using FluentValidation;
using OkyanusWebUI.Models.UserAdresVM;

namespace OkyanusWebUI.Validations
{
    public class CreateUserAdresVMValidator : AbstractValidator<CreateUserAdresVM>
    {
        public CreateUserAdresVMValidator()
        {
               RuleFor(x => x.UserAdress).NotEmpty().WithMessage("Adres Alanı Boş Geçilemez"); 
               RuleFor(x => x.UserApartman).NotEmpty().WithMessage("Apartman Alanı Boş Geçilemez"); 
               RuleFor(x => x.UserDaire).NotEmpty().WithMessage("Daire Alanı Boş Geçilemez"); 
               RuleFor(x => x.UserKat).NotEmpty().WithMessage("Kat Alanı Boş Geçilemez"); 
               RuleFor(x => x.UserSehir).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez"); 
               RuleFor(x => x.UserIlce).NotEmpty().WithMessage("İlçe Alanı Boş Geçilemez"); 
        }
    }
}
