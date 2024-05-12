using FluentValidation;
using OkyanusWebUI.Models.SssVM;

namespace OkyanusWebUI.Validations.Admin.SSS
{
    public class UpdateSssVMValidator : AbstractValidator<UpdateSssVM>
    {
        public UpdateSssVMValidator()
        {
            RuleFor(x => x.SssTitle).NotEmpty().WithMessage("Sık Sorulan Sorular Başlığı boş geçilemez!");
            RuleFor(x => x.SssContent).NotEmpty().WithMessage("Sık Sorulan Sorular İçeriği boş geçilemez!");
        }
    }
}
