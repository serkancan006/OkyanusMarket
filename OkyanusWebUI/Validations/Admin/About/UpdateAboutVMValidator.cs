using FluentValidation;
using OkyanusWebUI.Models.AboutVM;

namespace OkyanusWebUI.Validations.Admin.About
{
    public class UpdateAboutVMValidator : AbstractValidator<UpdateAboutVM>
    {
        public UpdateAboutVMValidator()
        {
            RuleFor(x => x.AboutDesc).NotNull().WithMessage("Hakkımızda Açıklaması boş geçilemez");
            RuleFor(x => x.Misyon).NotNull().WithMessage("Hakkımızda Misyonumuz boş geçilemez");
            RuleFor(x => x.Vizyon).NotNull().WithMessage("Hakkımızda Vizyonumuz boş geçilemez");
        }
    }
}
