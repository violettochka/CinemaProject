using FluentValidation;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.BLL.Services;
using ProjectCinema.Repositories.Classes;

namespace ProjectCinema.Validations.HallValidation
{
    public class HallCreateDTOValidator : AbstractValidator<HallCreateDTO>
    {
        private readonly ICinemaService _cinemaService;
        public HallCreateDTOValidator(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;

            RuleFor(h => h.HallName)
                .NotEmpty().WithMessage("Hall name is required field")
                .MaximumLength(265).WithMessage("Hall name cant contain more than 256 symbols");

            RuleFor(h => h.RowCount)
                .NotEmpty().WithMessage("Count of row is required field")
                .GreaterThan(0).WithMessage("Hall must contain at least one row ");

            RuleFor(h => h.CinemaId)
                .NotEmpty().WithMessage("Each hall must be connected to an existing cinema")
                .MustAsync(async (cinemaId, cancellation) =>
                await _cinemaService.GetByIdAsync(cinemaId) != null)
                .WithMessage("Cinema with this ID not found.");

        }
    }
}
