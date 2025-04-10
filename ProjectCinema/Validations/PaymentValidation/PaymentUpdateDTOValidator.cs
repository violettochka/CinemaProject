using FluentValidation;
using ProjectCinema.BLL.DTO.Payment;

namespace ProjectCinema.Validations.PaymentValidation
{
    public class PaymentUpdateDTOValidator : AbstractValidator<PaymentUpdateDTO>
    {
        public PaymentUpdateDTOValidator()
        {
            When(p => p.PeymentMethod.HasValue, () =>
            {
                RuleFor(p => p.PeymentMethod)
                    .IsInEnum().WithMessage("The specified payment method is incorrect.");
            });
        }
    }
}
