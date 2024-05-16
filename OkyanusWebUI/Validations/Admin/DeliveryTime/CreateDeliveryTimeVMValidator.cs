using FluentValidation;
using OkyanusWebUI.Models.DeliveryTimeVM;
using System;

namespace OkyanusWebUI.Validations.Admin.DeliveryTime
{
    public class CreateDeliveryTimeVMValidator : AbstractValidator<CreateDeliveryTimeVM>
    {
        public CreateDeliveryTimeVMValidator()
        {
            //RuleFor(x => x.DeliveryTimeName).NotNull().NotEmpty().WithMessage("Boş geçilemez");

            RuleFor(x => x.StartedTime)
                .NotEmpty().WithMessage("Başlangıç zamanı boş geçilemez")
                .Must(BeAValidDate).WithMessage("Başlangıç zamanı geçerli bir zaman olmalı");
                //.GreaterThanOrEqualTo(DateTime.Now.TimeOfDay).WithMessage("Başlangıç zamanı şuanki zamandan büyük olmalı");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Bitiş zamanı boş geçilemez")
                .Must(BeAValidDate).WithMessage("Bitiş zamanı geçerli bir zaman olmalı")
                .GreaterThanOrEqualTo(x => x.StartedTime).WithMessage("Bitiş zamanı başlangıç zamanından büyük olmalı");
        }

        private bool BeAValidDate(TimeSpan date)
        {
            return !date.Equals(default(TimeSpan));
        }
    }
}
