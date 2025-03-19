using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Entities
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int RowNumber { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int SeatNumber { get; set; }
        public SeatAvailability SeatAvailability { get; set; }
        [Required]
        public SeatType SeatType { get; set; } 
        [Required]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("HallId")]
        public Hall Hall { get; set; }
        [Required]
        public int HallId { get; set; } 
        public ICollection<Ticket> Tickets { get; set; }
    }
}
