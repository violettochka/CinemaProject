using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Booking;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPromocodeIdAsync(int promocodeId)
        {
            return await _dbContext.Bookings.AsNoTracking().Where(b => b.PromocodeId == promocodeId).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _dbContext.Bookings.AsNoTracking().Where(b =>b.UserId == userId).ToListAsync();
        }
    }
}
