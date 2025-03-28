using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.DAL.Interfaces;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Classes
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByBookingIdAsync(int id)
        {

            return await _dbContext.Tickets.AsNoTracking().Where(t => t.BookingId == id).ToListAsync();

        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySeatIdAsync(int seatId)
        {
            return await _dbContext.Tickets.AsNoTracking().Where(t => t.SeatId == seatId).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByShowTimeIdAsync(int id)
        {

            return await _dbContext.Tickets.AsNoTracking().Where(t => t.ShowTimeId == id).ToListAsync();

        }

        public async Task<IEnumerable<Ticket>> GetTicketsByTicketStatusAsync(TicketStatus? ticketStatus = null)
        {

            var query = _dbSet.AsQueryable();

            if (ticketStatus.HasValue)
            {
                query = query.AsNoTracking().Where(t => t.TicketStatus == ticketStatus.Value);
            }

            return await query.ToListAsync();

        }
    }
}
