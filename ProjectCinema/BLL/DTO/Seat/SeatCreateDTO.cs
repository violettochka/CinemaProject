using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Seat
{
    public class SeatCreateDTO
    {
        [Range(1, int.MaxValue)]
        [Required]
        public int RowNumber { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public SeatType SeatType { get; set; }
        [Required]
        public int HallId { get; set; }
    }
}
