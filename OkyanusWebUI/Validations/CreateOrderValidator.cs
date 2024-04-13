using FluentValidation;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(item => item.UserAdresID).NotEmpty().WithMessage("Lütfen Adres Seçiniz!");
            RuleFor(item => item.OrderItems).NotNull().WithMessage("Sipariş oluşturulmadı!");
            RuleFor(item => item.OrderItems).NotEmpty().WithMessage("Boş sipariş verilemez!");
            RuleFor(item => item.TotalPrice).GreaterThan(0).WithMessage("Toplam Fİyatın 0 dan büyük olması gerek");
        }
    }
}
