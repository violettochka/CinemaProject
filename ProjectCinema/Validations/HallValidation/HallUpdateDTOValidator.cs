using FluentValidation;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.Validations.HallValidation
{
    public class HallUpdateDTOValidator : AbstractValidator<HallUpdateDTO>
    {
        public HallUpdateDTOValidator()
        {

            When(h => h.HallName != null, () =>
            {
                RuleFor(x => x.HallName)
                    .Length(2, 256).WithMessage("Hall name must be between 2 and 256 characters long.");
            });

            When(h => h.RowCount.HasValue, () =>
            {
                RuleFor(x => x.RowCount)
                    .GreaterThan(0).WithMessage("Capacity must be a positive number.");
            });

            When(h => h.HallAvailability != HallAvailability.Undefined, () =>
            {
                RuleFor(h => h.HallAvailability)
                    .IsInEnum().WithMessage("Invalid promocode type.");
            });
        }
    }
}
