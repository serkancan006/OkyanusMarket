using FluentValidation;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            //RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");
            RuleFor(item => item.OrderItems).NotEmpty().WithMessage("boş sipariş verilememez!");
        }
    }
}
