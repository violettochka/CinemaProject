using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByStatusAsync(StatusOfMovie? movieStatus = null);
    }
}
