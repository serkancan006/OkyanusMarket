using FluentValidation;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(item => item.Price).NotNull().WithMessage("Fiyat null olamaz")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(item => item.TotalPrice).NotNull().WithMessage("Toplam Fiyat null olamaz")
                .GreaterThan(0).WithMessage("Toplam Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.Quantity).NotNull().WithMessage("Miktar null olamaz")
              .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır!")
              .Must((x, quantity) =>
              {
                  decimal remainder = quantity % x.IncreaseAmount;
                  return remainder == 0;
              }).WithMessage((x, quantity) => $"Miktar, {x.Birim} birimi için {x.IncreaseAmount} in katı olmalıdır.");
            RuleFor(x => x.Quantity)
                .LessThanOrEqualTo(x => x.Stock).WithMessage((x, stock) => $"Mevcut stok: {x.Stock} adet bulunmaktadır!");
        }
    }
}
