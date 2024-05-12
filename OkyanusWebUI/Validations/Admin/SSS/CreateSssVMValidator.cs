using FluentValidation;
using OkyanusWebUI.Models.SssVM;

namespace OkyanusWebUI.Validations.Admin.SSS
{
    public class CreateSssVMValidator : AbstractValidator<CreateSssVM>
    {
        public CreateSssVMValidator()
        {
            RuleFor(x => x.SssTitle).NotNull().NotEmpty().WithMessage("Sık Sorulan Sorular Başlığı boş geçilemez");
            RuleFor(x => x.SssContent).NotNull().NotEmpty().WithMessage("Sık Sorulan Sorular İçeriği boş geçilemez");
        }
    }
}
