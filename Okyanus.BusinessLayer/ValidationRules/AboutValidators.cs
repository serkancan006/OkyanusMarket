using FluentValidation;
using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.ValidationRules
{
    public class AboutValidators : AbstractValidator<About>
    {
        public AboutValidators()
        {
            RuleFor(x => x.misyon).NotEmpty().WithMessage("misyon boş olamaz");
        }
    }
}
