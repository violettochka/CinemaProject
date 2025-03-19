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
                query = query.Where(m => m.MovieScreeningRelevance == movieScreeningRelevance.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ShowTime>> GetShowTimesByMovieScreeningIdAsync(int id)
        {
            return await _dbContext.ShowTimes.Where(s => s.MovieScreeningId == id).ToListAsync();
        }

        public async Task<IEnumerable<MovieScreening>> GetMovieSreeningsByMovieIdAsync(int movieId)
        {
            return await _dbContext.MovieScreenings.Where(mv => mv.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<MovieScreening>> GetMovieScreeningssByCimenaIdAsync(int id)
        {
            return await _dbContext.MovieScreenings.Where(m => m.CinemaId == id).ToListAsync();
        }

    }
}
