using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> GetMoviesByStatusAsync(StatusOfMovie? movieStatus = null)
        {
            var query = _dbSet.AsQueryable();

            if (movieStatus.HasValue)
            {
                query = query.Where(m => m.Status == movieStatus.Value);
            }
            return await query.ToListAsync();
        }
    }
}
