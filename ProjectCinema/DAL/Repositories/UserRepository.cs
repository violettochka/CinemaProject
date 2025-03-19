using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int id)
        {
            return await _dbContext.Bookings.Where(b => b.UserId == id).ToListAsync();
        }
    }
}
