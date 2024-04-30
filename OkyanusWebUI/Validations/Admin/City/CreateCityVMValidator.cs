using FluentValidation;
using OkyanusWebUI.Models.CityVM;

namespace OkyanusWebUI.Validations.Admin.City
{
    public class CreateCityVMValidator : AbstractValidator<CreateCityVM>
    {
        public CreateCityVMValidator()
        {
            RuleFor(x => x.CityName).NotNull().WithMessage("Şehir adı boş geçilemez");
        }
    }
}
