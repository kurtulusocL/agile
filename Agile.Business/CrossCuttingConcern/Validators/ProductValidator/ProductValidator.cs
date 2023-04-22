using Agile.Entities.Concrete;
using FluentValidation;

namespace Agile.Business.CrossCuttingConcern.Validators.ProductValidator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                 .NotEmpty().NotNull().WithMessage("Product name can not be empty.");
            RuleFor(p => p.Price)
                 .NotEmpty().NotNull().WithMessage("Price can not be empty.");
            RuleFor(p => p.Description)
                 .NotEmpty().NotNull().WithMessage("Product description can not be empty.");
        }
    }
}
