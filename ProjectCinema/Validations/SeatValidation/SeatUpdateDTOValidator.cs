using FluentValidation;
using ProjectCinema.BLL.DTO.Seat;

namespace ProjectCinema.Validations.SeatValidation
{
    public class SeatUpdateDTOValidator : AbstractValidator<SeatUpdateDTO>
    {
        public SeatUpdateDTOValidator()
        {
            When(s => s.SeatAvailability.HasValue, () =>
            {
                RuleFor(x => x.SeatAvailability)
                    .IsInEnum().WithMessage("Invalid seat availability status.");
            });

            When(s => s.SeatType.HasValue, () =>
            {
                RuleFor(x => x.SeatType)
                    .IsInEnum().WithMessage("Invalid seat type.");
            });

        }
    }
}
