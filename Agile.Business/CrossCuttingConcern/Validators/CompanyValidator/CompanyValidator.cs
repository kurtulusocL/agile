using Agile.Entities.Concrete;
using FluentValidation;

namespace Agile.Business.CrossCuttingConcern.Validators.CompanyValidator
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().NotNull().WithMessage("Company name can not be empty.");            
        }
    }
}
