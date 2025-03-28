using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        public SeatRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Seat>> GetSeatsAvailibilityAsync(SeatAvailability? seatAvailability = null)
        {
            var query = _dbSet.AsQueryable();
            if (seatAvailability.HasValue)
            {
                query = query.AsNoTracking().Where(s => s.SeatAvailability == seatAvailability.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetSeatsByHallIdAsync(int id)
        {

            return await _dbContext.Seats.AsNoTracking().Where(s => s.HallId == id).ToListAsync();

        }
    }
}
