using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Booking;

namespace ProjectCinema.BLL.DTO.Promocode
{
    public class PromocodeDetailsDTO
    {
        public int PromocodeId { get; set; }
        public string? UniqueCode { get; set; }
        public PromocodeType PromocodeType { get; set; }
        public Decimal PromocodeAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Condition { get; set; }
        public ICollection<BookingDTO>? Bookings { get; set; }
    }
}
