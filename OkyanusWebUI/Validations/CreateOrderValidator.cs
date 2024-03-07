using FluentValidation;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(item => item.OrderAdress).NotEmpty().WithMessage("Lütfen Adres giriniz!");
            RuleFor(item => item.OrderApartmanNo).NotEmpty().WithMessage("Lütfen Apartman numarası giriniz!");
            RuleFor(item => item.OrderDaireNo).NotEmpty().WithMessage("Lütfen Daire numarası giriniz!");
            RuleFor(item => item.OrderKat).NotEmpty().WithMessage("Lütfen Kat giriniz!");
            RuleFor(item => item.OrderSehir).NotEmpty().WithMessage("Lütfen Şehir giriniz!");
            RuleFor(item => item.OrderIlce).NotEmpty().WithMessage("Lütfen İlçe giriniz!");
            RuleFor(item => item.OrderFirstName).NotEmpty().WithMessage("Lütfen Adınızı giriniz!");
            RuleFor(item => item.OrderSurname).NotEmpty().WithMessage("Lütfen Soyadınızı giriniz!");
            RuleFor(item => item.OrderMail).NotEmpty().WithMessage("Lütfen Mail Adresinizi giriniz!");
            RuleFor(item => item.OrderPhone).NotEmpty().WithMessage("Lütfen Telefon Numarası giriniz!");
            RuleFor(item => item.OrderItems).NotNull().WithMessage("Sipariş oluşturulmadı!");
            RuleFor(item => item.OrderItems).NotEmpty().WithMessage("Boş sipariş verilemez!");
            RuleFor(item => item.TotalPrice).GreaterThan(0).WithMessage("Toplam Fİyatın 0 dan büyük olması gerek");
        }
    }
}
