using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.Enums;

namespace ProjectCinema.Entities
{
    public class Hall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int HallId { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string HallName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public HallAvailability HallAvailability { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }
        [Required]
        public int CinemaId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<ShowTime> ShowTimes { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
