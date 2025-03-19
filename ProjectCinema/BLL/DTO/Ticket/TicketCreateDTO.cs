using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Ticket
{
    public class TicketCreateDTO
    {
        [Required]
        public Decimal PriceAtPurchase { get; set; }
        [Required]
        public int ShowTimeId { get; set; }
        [Required]
        public int SeatId { get; set; }
        [Required]
        public int BookingId { get; set; }
    }
}
