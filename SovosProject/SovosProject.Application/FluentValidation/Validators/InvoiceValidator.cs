using FluentValidation;
using SovosProject.Application.Models;
namespace SovosProject.Application.FluentValitaion.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceHeaderDto>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.InvoiceId)
            .NotEmpty().WithMessage("Invoice Id boş olamaz.")
             .MaximumLength(20).WithMessage("Invoice Id en fazla 20 karakter içermeli.");

            RuleFor(x => x.SenderTitle)
          .NotEmpty().WithMessage("Sender title boş olamaz.");

            RuleFor(x => x.ReceiverTitle)
                .NotEmpty().WithMessage("Receiver title alanı boş olamaz.");

            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email alnı boş olamaz.")
           .EmailAddress().WithMessage("Email mail formatına uygun değildir.");
        }
    }
}
