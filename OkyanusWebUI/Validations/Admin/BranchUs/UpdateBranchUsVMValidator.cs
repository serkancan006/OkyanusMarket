using FluentValidation;
using OkyanusWebUI.Models.BranchUsVM;

namespace OkyanusWebUI.Validations.Admin.BranchUs
{
    public class UpdateBranchUsVMValidator : AbstractValidator<UpdateBranchUsVM>
    {
        public UpdateBranchUsVMValidator()
        {
            RuleFor(x => x.BranchAdres).NotNull().WithMessage("Şube Adres alanı boş geçilemez");
        }
    }
}
