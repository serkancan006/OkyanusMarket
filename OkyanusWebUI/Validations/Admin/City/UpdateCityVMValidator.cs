using FluentValidation;
using OkyanusWebUI.Models.CityVM;

namespace OkyanusWebUI.Validations.Admin.City
{
    public class UpdateCityVMValidator : AbstractValidator<UpdateCityVM>
    {
        public UpdateCityVMValidator()
        {
            RuleFor(x => x.CityName).NotNull().WithMessage("Şehir adı boş geçilemez");
        }
    }
}
