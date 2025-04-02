using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IMovieScreeningRepository : IGenericRepository<MovieScreening>
    {
        Task<IEnumerable<MovieScreening>> GetMovieScreeningsByRelevanceAsync(MovieScreeningRelevance? movieScreeningRelevance = null);

        Task<IEnumerable<MovieScreening>> GetMovieSreeningsByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieScreening>> GetMovieScreeningsByCimenaIdAsync(int cinemaId);

        Task<bool> IsMovieScreeningExistsByCinemaAndMovieAsync(int cinemaId, int movieId);
        Task<IEnumerable<MovieScreening>> GetOverlappingScreeningsAsync(int cinemaId, DateTime startTime, DateTime endTime);
    }
}
