using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.ShowTime
{
    public class ShowTimeCreateDTO
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public ViewingFormat ViewingFormat { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public Decimal TicketPrice { get; set; }
        [Required]
        public int MovieScreeningId { get; set; }
        [Required]
        public int HallId { get; set; }
    }
}
