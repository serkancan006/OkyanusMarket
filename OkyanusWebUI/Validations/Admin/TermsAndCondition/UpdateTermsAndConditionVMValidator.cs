using FluentValidation;
using OkyanusWebUI.Models.TermsAndConditionVM;

namespace OkyanusWebUI.Validations.Admin.TermsAndCondition
{
    public class UpdateTermsAndConditionVMValidator : AbstractValidator<UpdateTermsAndConditionVM>
    {
        public UpdateTermsAndConditionVMValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Şartlar ve Koşullar içi başlık alanı boş geçilemez");
            RuleFor(x => x.Content).NotNull().WithMessage("Şartlar ve Koşullar içi içerik alanı boş geçilemez");
        }
    }
}
