using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IMovieScreeningRepository : IGenericRepository<MovieScreening>
    {
        Task<IEnumerable<MovieScreening>> GetMovieScreeningsByRelevanceAsync(MovieScreeningRelevance? movieScreeningRelevance = null);
        Task<IEnumerable<ShowTime>> GetShowTimesByMovieScreeningIdAsync(int id);

        Task<IEnumerable<MovieScreening>> GetMovieSreeningsByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieScreening>> GetMovieScreeningssByCimenaIdAsync(int cinemaId);
    }
}
