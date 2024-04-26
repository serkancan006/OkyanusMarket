using FluentValidation;
using OkyanusWebUI.Models.SocialMediaVM;

namespace OkyanusWebUI.Validations.Admin.SocialMedia
{
    public class UpdateSocialMediaVMValidator : AbstractValidator<UpdateSocialMediaVM>
    {
        public UpdateSocialMediaVMValidator()
        {
            RuleFor(x => x.MediaUrl).NotNull().WithMessage("Sosyal Medya Url alanı Boş geçilemez");
        }
    }
}
