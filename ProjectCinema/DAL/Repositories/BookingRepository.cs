using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Ticket>> GetTicketsByBookingIdAsync(int id)
        {

            return await _dbContext.Tickets.Where(t => t.BookingId == id).ToListAsync();

        }
    }
}
