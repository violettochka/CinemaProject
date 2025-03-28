using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class MovieScreeningRepository : GenericRepository<MovieScreening>, IMovieScreeningRepository
    {

        public MovieScreeningRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MovieScreening>> GetMovieScreeningsByRelevanceAsync(
                                                       MovieScreeningRelevance? movieScreeningRelevance = null)
        {

            var query = _dbSet.AsQueryable();

            if (movieScreeningRelevance.HasValue)
            {
                query = query.AsNoTracking().Where(m => m.MovieScreeningRelevance == movieScreeningRelevance.Value);
            }

            return await query.Include(m => m.ShowTimes).ToListAsync();

        }


        public async Task<IEnumerable<MovieScreening>> GetMovieSreeningsByMovieIdAsync(int movieId)
        {

            return await _dbContext.MovieScreenings
                                   .AsNoTracking()
                                   .Where(mv => mv.MovieId == movieId)
                                   .Include(m => m.ShowTimes)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<MovieScreening>> GetMovieScreeningsByCimenaIdAsync(int id)
        {
            
            return await _dbContext.MovieScreenings
                                   .AsNoTracking()
                                   .Where(m => m.CinemaId == id)
                                   .Include(m => m.ShowTimes)
                                   .ToListAsync();

        }

    }
}
