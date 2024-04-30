using FluentValidation;
using OkyanusWebUI.Models.DistrictVM;

namespace OkyanusWebUI.Validations.Admin.District
{
    public class UpdateDistrictVMValidator : AbstractValidator<UpdateDistrictVM>
    {
        public UpdateDistrictVMValidator()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("İlçe adı girmek zorunludur.");
            RuleFor(x => x.CityID).NotEmpty().WithMessage("İl bilgisini seçiniz.");
        }
    }
}
