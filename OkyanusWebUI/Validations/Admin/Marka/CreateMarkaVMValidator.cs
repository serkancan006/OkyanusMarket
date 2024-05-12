using FluentValidation;
using OkyanusWebUI.Models.MarkaVM;

namespace OkyanusWebUI.Validations.Admin.Marka
{
    public class CreateMarkaVMValidator : AbstractValidator<CreateMarkaVM>
    {
        public CreateMarkaVMValidator()
        {
            RuleFor(x => x.MarkaAdı).NotNull().WithMessage("Marka Adı Boş geçilemez");
        }
    }
}
