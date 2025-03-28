using ProjectCinema.BLL.DTO.Booking;
using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByPromocodeIdAsync(int promocodeId);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
    }
}
