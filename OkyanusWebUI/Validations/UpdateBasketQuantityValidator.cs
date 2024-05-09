using FluentValidation;
using OkyanusWebUI.Controllers;

namespace OkyanusWebUI.Validations
{
    public class UpdateBasketQuantityValidator : AbstractValidator<UpdateBasketQuantity>
    {
        public UpdateBasketQuantityValidator()
        {
            RuleFor(x => x.quantity).LessThan(x => x.stock).WithMessage((x, stock) => $"Mevcut stok: {x.stock} adet bulunmaktadır!");
        }
    }
}
