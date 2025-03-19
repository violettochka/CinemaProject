using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Users;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.BLL.DTO.Payment;

namespace ProjectCinema.BLL.DTO.Booking
{
    public class BookingDetailsDTO
    {
        public int BookingId { get; set; }
        public Decimal TotalPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
       
        public UserDTO? User { get; set; }

        public PaymentDTO? Payment { get; set; }

        public PromocodeDTO? Promocode { get; set; }

        public ICollection<TicketDTO>? Tickets { get; set; }
    }
}
