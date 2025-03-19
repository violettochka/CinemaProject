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
                query = query.Where(s => s.ShowTimeStatus == showTimeStatus.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByShowTimeAsync(int id)
        {
            return await _dbContext.Tickets.Where(t => t.ShowTimeId == id).ToListAsync();
        }
    }
}
