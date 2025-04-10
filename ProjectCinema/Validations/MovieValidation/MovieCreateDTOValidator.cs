using FluentValidation;
using ProjectCinema.BLL.DTO.Movie;

namespace ProjectCinema.Validations.MovieValidation
{
    public class MovieCreateDTOValidator : AbstractValidator<MovieCreateDTO>
    {
        public MovieCreateDTOValidator()
        {
            RuleFor(m => m.MovieName)
                .NotEmpty().WithMessage("Movie name is required field")
                .Length(1, 256).WithMessage("Movie name must be in a range beetween 1 and 256")
                .Matches(@"^[\w\s\p{P}]+$").WithMessage("Movie name contains unacceptable symbols");

            RuleFor(m => m.DurationInMinutes)
                .NotEmpty().WithMessage("Movie duration is a required field")
                .GreaterThan(0).WithMessage("Movie duretion can't be negative");

            RuleFor(m => m.AgeRestriction)
                .NotEmpty().WithMessage("Age restriction is a required field")
                .InclusiveBetween(0, 21).WithMessage("Age restriction must be beetween 0 and 21 inclusive");

            RuleFor(m => m.ReleaseYear)
                .NotEmpty().WithMessage("Movie release year is a required field")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Release year cant be in a future")
                .GreaterThanOrEqualTo(new DateOnly(1895, 1, 1))
                .WithMessage("Release year cant be early than 1895 year");

            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("Movie genre is required field")
                .Length(2, 128).WithMessage("Movie language must be in a range beetween 2 and 128");

            RuleFor(x => x.Language)
                .NotEmpty().WithMessage("Movie language is required field")
                .Length(2, 64).WithMessage("Movie language must be in a range beetween 2 and 64")
                .Matches(@"^[A-Za-zА-Яа-яёЁ\s\-]+$")
                .WithMessage("Unacceptable symbols in a name of language");

            RuleFor(x => x.ProductionStudio)
                .MaximumLength(256).WithMessage("ProductionStudio must be less or equal 256 symbols");

            RuleFor(x => x.Director)
                .MaximumLength(256).WithMessage("Director must be less or equal 256 symbols");

            RuleFor(x => x.MainCast)
                .MaximumLength(1024).WithMessage("Director must be less or equal 1024 symbols");
        }
    }
}
