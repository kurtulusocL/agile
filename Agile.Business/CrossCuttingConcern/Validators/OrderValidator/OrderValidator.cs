using Agile.Entities.Concrete;
using FluentValidation;

namespace Agile.Business.CrossCuttingConcern.Validators.OrderValidator
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {            
            RuleFor(p => p.OrderDate)
                 .NotEmpty().NotNull().WithMessage("OrderDate can not be empty.");
            RuleFor(p => p.ExpectedOrderDate)
                 .NotEmpty().NotNull().WithMessage("ExpectedOrderDate can not be empty.");
            RuleFor(p => p.Quantity)
                 .NotEmpty().NotNull().WithMessage("Quantity can not be empty.");
        }
    }
}
