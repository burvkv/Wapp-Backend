using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class DebitValidator : AbstractValidator<Debit>
    {
        public DebitValidator()
        {
            RuleFor(x => x.DebitStatusId).NotEmpty();
            RuleFor(x => x.HardwareId).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
            RuleFor(x => x.ProjectId).NotEmpty();
        }
    }
}
