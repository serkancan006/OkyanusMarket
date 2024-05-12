using FluentValidation;
using OkyanusWebUI.Controllers;

namespace OkyanusWebUI.Validations
{
    public class UpdateBasketQuantityValidator : AbstractValidator<UpdateBasketQuantity>
    {
        public UpdateBasketQuantityValidator()
        {
            RuleFor(x => x.quantity)
               .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır!")
               .Must((x, quantity) =>
               {
                   decimal remainder = quantity % x.increaseAmount;
                   return remainder == 0;
               }).WithMessage((x, quantity) => $"Miktar, {x.birim} birimi için {x.increaseAmount} in katı olmalıdır.");
            RuleFor(x => x.quantity)
                .LessThanOrEqualTo(x => x.stock).WithMessage((x, stock) => $"Mevcut stok: {x.stock} adet bulunmaktadır!");
        }
    }
}
