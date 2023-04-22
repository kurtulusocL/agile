using Agile.Entities.Concrete;
using FluentValidation;

namespace Agile.Business.CrossCuttingConcern.Validators.SendMailValidator
{
    public class SendMailValidator : AbstractValidator<SendMail>
    {
        public SendMailValidator()
        {
            RuleFor(p => p.SenderEmail)
                 .NotEmpty().NotNull().WithMessage("Sender email address can not be empty.").EmailAddress();
            RuleFor(p => p.RecieverEmail)
                 .NotEmpty().NotNull().WithMessage("Reciever email address can not be empty.").EmailAddress();
            RuleFor(p => p.Subject)
                 .NotEmpty().NotNull().WithMessage("Email subject can not be empty.");
            RuleFor(p => p.MailText)
                 .NotEmpty().NotNull().WithMessage("Email text can not be empty.");
        }
    }
}
