using Entity.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.EnterDate).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.ProjectId).NotEmpty();
        }
    }
}
