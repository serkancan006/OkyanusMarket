using FluentValidation;
using OkyanusWebUI.Models.DeliveryTimeVM;

namespace OkyanusWebUI.Validations.Admin.DeliveryTime
{
    public class UpdateDeliveryTimeVMValidator : AbstractValidator<UpdateDeliveryTimeVM>
    {
        public UpdateDeliveryTimeVMValidator()
        {
            RuleFor(x => x.StartedTime).NotEmpty().NotEmpty().WithMessage("Başlangıç zamanı boş geçilemez");
            RuleFor(x => x.EndTime).NotEmpty().NotEmpty().WithMessage("Bitiş zamanı boş geçilemez");
        }
    }
}
