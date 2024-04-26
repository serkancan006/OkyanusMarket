using FluentValidation;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");
            //RuleFor(item => item.Quantity).Must((item, quantity) => IsQuantityValid(item.Birim, quantity))
            //                            .WithMessage("Miktar uygun değil");
            RuleFor(item => item.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
        }

        private bool IsQuantityValid(string birim, double quantity)
        {
            if (birim == "Kg")
            {
                // Birim Kg ise, ondalıklı sayı olabilir
                return quantity >= 0;
            }
            else if (birim == "Adet")
            {
                // Birim Adet ise, tam sayı olmalıdır
                return quantity % 1 == 0 && quantity >= 0;
            }
            return false;
        }

    }
}
