using FluentValidation;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(item => item.UserAdresID).NotNull().WithMessage("Lütfen Adres Seçiniz!");
            RuleFor(item => item.OrderItems).NotNull().WithMessage("Boş sipariş verilemez!");
            RuleFor(item => item.TelefonNo).NotNull().WithMessage("Lütfen Telefon NUmaranızı Giriniz!");
            RuleFor(item => item.TotalPrice).GreaterThan(0).WithMessage("Toplam Fİyatın 0 dan büyük olması gerek");
        }
    }
}
