using FluentValidation;
using OkyanusWebUI.Models.ProductTypeVM;

namespace OkyanusWebUI.Validations.Admin.ProductType
{
    public class CreateProductTypeVMValidator : AbstractValidator<CreateProductTypeVM>
    {
        public CreateProductTypeVMValidator()
        {
            RuleFor(x => x.Birim).NotNull().WithMessage("Birim Alanı Boş geçilemez");
            RuleFor(x => x.IncreaseAmount).NotNull().WithMessage("Artış Miktarı Alanı Boş geçilemez");
        }
    }
}
