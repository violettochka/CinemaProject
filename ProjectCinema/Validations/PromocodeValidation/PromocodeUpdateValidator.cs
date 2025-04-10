using FluentValidation;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.Enums;

namespace ProjectCinema.Validations.PromocodeValidation
{
    public class PromocodeUpdateValidator : AbstractValidator<PromocodeUpdateDTO>
    {
        public PromocodeUpdateValidator()
        {
            When(p => p.UniqueCode != null, () =>
                RuleFor(x => x.UniqueCode)
                    .NotEmpty().WithMessage("Unique code is required.")
                    .Length(3, 64).WithMessage("Unique code must be between 3 and 64 characters.")
            );

            When(p => p.PromocodeType != PromocodeType.Undefined, () =>
                RuleFor(x => x.PromocodeType)
                    .IsInEnum().WithMessage("Invalid promocode type.")
            );

            When(p => p.PromocodeAmount.HasValue, () =>
                RuleFor(x => x.PromocodeAmount)
                    .GreaterThan(0).WithMessage("Amount must be greater than 0.")
            );

            When(p => p.ExpiryDate.HasValue, () =>
                RuleFor(x => x.ExpiryDate)
                    .GreaterThan(DateTime.Now).WithMessage("Expiry date must be in the future.")
            );

            RuleFor(p => p.Condition)
                .MaximumLength(500).WithMessage("Condition must be at least 3 characters long.");
        }
    }
}
