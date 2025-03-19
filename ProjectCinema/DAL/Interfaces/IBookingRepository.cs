using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Ticket>> GetTicketsByBookingIdAsync(int id);
    }
}
