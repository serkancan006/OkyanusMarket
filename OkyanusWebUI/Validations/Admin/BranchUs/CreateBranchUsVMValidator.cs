using FluentValidation;
using OkyanusWebUI.Models.BranchUsVM;

namespace OkyanusWebUI.Validations.Admin.BranchUs
{
    public class CreateBranchUsVMValidator : AbstractValidator<CreateBranchUsVM>
    {
        public CreateBranchUsVMValidator()
        {
            RuleFor(x => x.BranchAdres).NotNull().WithMessage("Şube Adresi Boş geçilemez");
        }
    }
}
