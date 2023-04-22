using Agile.Entities.Concrete;
using FluentValidation;

namespace Agile.Business.CrossCuttingConcern.Validators.CustomerValidator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.NameSurname)
                 .NotEmpty().NotNull().WithMessage("Name Surname can not be empty.");
            RuleFor(p => p.PhoneNumber)
                 .NotEmpty().NotNull().WithMessage("Phone number can not be empty.");
            RuleFor(p => p.Email)
                 .NotEmpty().NotNull().WithMessage("Email can not be empty.").EmailAddress();
        }
    }
}
