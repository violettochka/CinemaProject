using FluentValidation;
using ProjectCinema.BLL.DTO.Movie;

namespace ProjectCinema.Validations.MovieValidation
{
    public class MovieUpdateDTOValidator : AbstractValidator<MovieUpdateDTO>
    {
        public MovieUpdateDTOValidator()
        {
            When(x => x.MovieName != null, () =>
            {
                RuleFor(x => x.MovieName)
                    .Length(1, 256).WithMessage("Movie name must be between 1 and 256 characters.");
            });

            When(x => x.DurationInMinutes.HasValue, () =>
            {
                RuleFor(x => x.DurationInMinutes.Value)
                    .InclusiveBetween(1, 600).WithMessage("Duration must be greater than 0.");
            });

            When(x => x.AgeRestriction.HasValue, () =>
            {
                RuleFor(x => x.AgeRestriction.Value)
                    .InclusiveBetween(0, 21).WithMessage("Age restriction must be between 0 and 21.");
            });

            When(x => x.ReleaseYear.HasValue, () =>
            {
                RuleFor(x => x.ReleaseYear.Value)
                    .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                    .GreaterThanOrEqualTo(new DateOnly(1895, 1, 1));
            });

            When(x => x.Genre != null, () =>
            {
                RuleFor(x => x.Genre)
                    .Length(2, 128).WithMessage("Genre must be between 2 and 128 characters.");
            });

            When(x => x.Language != null, () =>
            {
                RuleFor(x => x.Language)
                    .Length(2, 64)
                    .WithMessage("Language must be between 2 and 64 characters.")
                    .Matches(@"^[A-Za-zА-Яа-яёЁ\s\-]+$");
            });

            When(x => x.ProductionStudio != null, () =>
            {
                RuleFor(x => x.ProductionStudio)
                    .Length(1, 256)
                    .WithMessage("Production studio must be between 1 and 256 characters.");
            });

            When(x => x.Director != null, () =>
            {
                RuleFor(x => x.Director)
                    .Length(1, 256)
                    .WithMessage("Director must be between 1 and 256 characters.");
            });

            When(x => x.MainCast != null, () =>
            {
                RuleFor(x => x.MainCast)
                    .MaximumLength(1024)
                    .WithMessage("Main cast must be between 1 and 256 characters.");
            });

            When(x => x.Status.HasValue, () =>
            {
                RuleFor(x => x.Status.Value)
                    .IsInEnum();
            });
        }
    }
}
