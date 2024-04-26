using FluentValidation;
using OkyanusWebUI.Areas.Admin.Models.AdminGroupVM;

namespace OkyanusWebUI.Validations.Admin.AdminGroup
{
    public class UpdateGroupVMValidator : AbstractValidator<UpdateGroupVM>
    {
        public UpdateGroupVMValidator()
        {
            RuleFor(x => x.ANAGRUP).NotNull().WithMessage("Ana Grup alanı boş geçilmez");
            RuleFor(x => x.GRUPADI).NotNull().WithMessage("Grup adı alanı boş geçilmez");
        }
    }
}
