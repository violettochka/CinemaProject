using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Seat
{
    public class SeatUpdateDTO
    {
        public int SeatId { get; set; }
        [Range(1, int.MaxValue)]
        public int RowNumber { get; set; }
        [Range(1, int.MaxValue)]
        public int SeatNumber { get; set; }
        public SeatAvailability SeatAvailability { get; set; }
        public SeatType SeatType { get; set; }
    }
}
