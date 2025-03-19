using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetSeatsAsync(SeatAvailability? seatAvailability = null);
    }
}
