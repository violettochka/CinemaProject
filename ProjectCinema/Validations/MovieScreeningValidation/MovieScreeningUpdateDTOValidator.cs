using FluentValidation;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.BLL.Interfaces.IMovieScreeningServices;
using ProjectCinema.BLL.Services;

namespace ProjectCinema.Validations.MovieScreeningValidation
{
    public class MovieScreeningUpdateDTOValidator : AbstractValidator<MovieScreeningUpdateDTO>
    {
        public MovieScreeningUpdateDTOValidator(IMovieScreeningValidationService movieScreeningValidationService,
                                                ICinemaService cinemaService,
                                                IMovieService movieService)
        {

            When(m => m.StartDate.HasValue, () =>
            {
                RuleFor(x => x.StartDate)
                    .GreaterThan(DateTime.UtcNow)
                    .WithMessage("The screening start time cannot be in the past.");
            });

            When(m => m.EndDate.HasValue, () =>
            {
                RuleFor(x => x.EndDate)
                    .GreaterThan(x => x.StartDate)
                    .WithMessage("End time must be after start time.");
            });

            When(m => m.MovieScreeningRelevance.HasValue, () =>
            {
                RuleFor(x => x.MovieScreeningRelevance)
                    .IsInEnum()
                    .WithMessage("Invalid screening relevance.");
            });
        }
    }
}
