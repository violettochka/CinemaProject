using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
    {
        public ShowTimeRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShowTime>> GetShowTimesAsync(ShowTimeStatus? showTimeStatus = null)
        {

            var query = _dbSet.AsQueryable();

            if(showTimeStatus.HasValue)
            {

                query = query.AsNoTracking().Where(s => s.ShowTimeStatus == showTimeStatus.Value);

            }

            return await query.Include(t => t.Tickets).ToListAsync();

        }

        public async Task<IEnumerable<ShowTime>> GetShowTimesByMovieScreeningIdAsync(int id)
        {

            return await _dbContext.ShowTimes
                                    .AsNoTracking()
                                    .Where(s => s.MovieScreeningId == id)
                                    .Include(t => t.Tickets)
                                    .ToListAsync();

        }

        public async Task<IEnumerable<ShowTime>> GetShowTimesByHallIdAsync(int id)
        {

            return await _dbContext.ShowTimes
                                    .AsNoTracking()
                                    .Where(s => s.HallId == id)
                                    .Include(t => t.Tickets)
                                    .ToListAsync();

        }
    }
}
