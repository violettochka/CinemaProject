using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Booking;

namespace ProjectCinema.BLL.DTO.Payment
{
    public class PaymentDetailsDTO
    {
        public int PaymentId { get; set; }
        public PaymentMethod PeymentMethod { get; set; }
        public Decimal AmountPaid { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }
        public BookingDTO? Booking { get; set; }
    }
}
