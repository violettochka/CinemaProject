using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.Interfaces.IMovieScreeningServices
{
    public interface IMovieScreeningQueryService
    {
        Task<IEnumerable<MovieScreeningDTO>> GetMovieScreeningsByRelevanceAsync(MovieScreeningRelevance relevance);
        Task<IEnumerable<MovieScreeningDTO>> GetMovieSreeningsByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieScreeningDetailsDTO>> GetScreeningsDetailsByMovieIdAsync(int movieId);
    }
}
