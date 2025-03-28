using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.DAL.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByTicketStatusAsync(TicketStatus? ticketStatus = null);
        Task<IEnumerable<Ticket>> GetTicketsByBookingIdAsync(int bookingId);
        Task<IEnumerable<Ticket>> GetTicketsBySeatIdAsync(int seatId);
        Task<IEnumerable<Ticket>> GetTicketsByShowTimeIdAsync(int shoeTimeId);
    }
}
