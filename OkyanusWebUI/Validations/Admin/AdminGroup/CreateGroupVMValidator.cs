using FluentValidation;
using OkyanusWebUI.Areas.Admin.Models.AdminGroupVM;

namespace OkyanusWebUI.Validations.Admin.AdminGroup
{
    public class CreateGroupVMValidator : AbstractValidator<CreateGroupVM>
    {
        public CreateGroupVMValidator()
        {
            RuleFor(x => x.ANAGRUP).NotNull().WithMessage("Ana grup alanı boş geçilemez");
            RuleFor(x => x.GRUPADI).NotNull().WithMessage("Grup adı alanı boş geçilemez");
        }
    }
}
