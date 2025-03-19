using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Payment
{
    public class PaymentCreateDTO
    {
        [Required]
        public PaymentMethod PeymentMethod { get; set; }
        [Required]
        public Decimal AmountPaid { get; set; }
        [Required]
        public int BookingId { get; set; }
    }
}
