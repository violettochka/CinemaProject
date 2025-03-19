using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Entities
{
    public class Promocode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromocodeId { get; set; }
        [Required]
        public string UniqueCode { get; set; }
        [Required]
        public PromocodeType PromocodeType { get; set; }
        public Decimal PromocodeAmount { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Condition { get; set; }
        [Required]
        public DateTime CreatedAdt { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
