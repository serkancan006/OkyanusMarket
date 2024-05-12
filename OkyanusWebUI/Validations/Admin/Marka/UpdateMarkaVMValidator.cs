using FluentValidation;
using OkyanusWebUI.Models.MarkaVM;

namespace OkyanusWebUI.Validations.Admin.Marka
{
    public class UpdateMarkaVMValidator : AbstractValidator<UpdateMarkaVM>
    {
        public UpdateMarkaVMValidator()
        {
            RuleFor(x => x.MarkaAdı).NotNull().WithMessage("Marka Adı Boş geçilemez");
        }
    }
}
