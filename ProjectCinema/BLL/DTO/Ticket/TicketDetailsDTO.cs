using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.Booking;

namespace ProjectCinema.BLL.DTO.Ticket
{
    public class TicketDetailsDTO
    {

        public int TicketId { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public Decimal PriceAtPurchase { get; set; }
        public ShowTimeDTO? ShowTime { get; set; }
        public SeatDTO? Seat { get; set; }
        public BookingDTO? Booking { get; set; }
    }
}
