using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class HardwareValidator : AbstractValidator<Hardware>
    {
        public HardwareValidator()
        {
            RuleFor(x => x.IsDebitted).NotEmpty();
            RuleFor(x => x.IsDefective).NotEmpty();
            RuleFor(x => x.Barcode).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.LabelId).NotEmpty();
            
        }
    }
}
