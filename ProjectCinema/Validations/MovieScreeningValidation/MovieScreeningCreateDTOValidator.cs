using FluentValidation;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.BLL.Interfaces.IMovieScreeningServices;
using ProjectCinema.BLL.Services;

namespace ProjectCinema.Validations.MovieScreeningValidation
{
    public class MovieScreeningCreateDTOValidator : AbstractValidator<MovieScreeningCreateDTO>
    {
        private readonly ICinemaService _cinemaService;
        public MovieScreeningCreateDTOValidator(ICinemaService cinemaService,
                                                IMovieService movieService,
                                                IMovieScreeningValidationService movieScreeningValidationService)
        {
            _cinemaService = cinemaService;

            RuleFor(h => h.CinemaId)
                .NotEmpty().WithMessage("Each Movie screening must be connected to an existing cinema")
                .MustAsync(async (cinemaId, cancellation) =>
                await _cinemaService.GetByIdAsync(cinemaId) != null)
                .WithMessage("Cinema with this ID not found.");

            RuleFor(x => x.MovieId)
                .NotEmpty().WithMessage("Each Movie screening must be connected to an existing movie")
                .MustAsync(async (movieId, cancellation) =>
                    await movieService.GetByIdAsync(movieId) != null)
                .WithMessage("Movie with this ID not found.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                    !await movieScreeningValidationService.IsMovieScreeningExistsByCinemaAndMovieAsync(dto.CinemaId, dto.MovieId))
                .WithMessage("A screening of this film already exists in this cinema.");

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("The screening start time cannot be in the past.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                {
                    var overlapping = await movieScreeningValidationService
                                .GetOverlappingScreeningsAsync(dto.CinemaId, dto.StartDate, dto.EndDate);
                    return !overlapping.Any();
                })
                .WithMessage("The screening time overlaps with another performance at this cinema.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("End time must be after start time.");
        }
    }
}
