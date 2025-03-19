using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public PaymentMethod PeymentMethod { get; set; }
        [Required]
        public Decimal AmountPaid { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public DateTime PaidAt { get; set; }
        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
        [Required]
        public int BookingId { get; set; }
    }
}
