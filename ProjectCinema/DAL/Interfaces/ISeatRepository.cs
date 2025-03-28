using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetSeatsAvailibilityAsync(SeatAvailability? seatAvailability = null);
        Task<IEnumerable<Seat>> GetSeatsByHallIdAsync(int id);
    }
}
