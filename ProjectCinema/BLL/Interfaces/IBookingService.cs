using ProjectCinema.BLL.DTO.Booking;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IBookingService : IGenericService<BookingDTO, Booking>
    {
        Task<BookingDTO> CreateBookingAsync(BookingCreateDTO bookingCreateDTO);
        Task<BookingDTO> UpdateBookingAsync(BookingUpdateDTO bookingUpdateDTO, int bookingId);
        Task<BookingDetailsDTO> GetBookingDetailsByIdAsync(int bookingId);
        Task<IEnumerable<BookingDTO>> GetBookingsByUserIdAsync (int userId);
        Task<IEnumerable<BookingDTO>> GetBookingsByPromocodeIdAsync (int promocodeId);

    }
}
