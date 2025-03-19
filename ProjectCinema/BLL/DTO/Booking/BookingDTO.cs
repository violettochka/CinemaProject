using ProjectCinema.BLL.DTO.Users;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.DTO.Booking
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
