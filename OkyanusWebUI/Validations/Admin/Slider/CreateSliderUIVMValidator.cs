using FluentValidation;
using OkyanusWebUI.Areas.Admin.Models.SliderUIVM;

namespace OkyanusWebUI.Validations.Admin.Slider
{
    public class CreateSliderUIVMValidator : AbstractValidator<CreateSliderUIVM>
    {
        public CreateSliderUIVMValidator()
        {
            RuleFor(x => x.file).NotEmpty().WithMessage("Lütfen bir dosya seçiniz");
        }
    }
}
