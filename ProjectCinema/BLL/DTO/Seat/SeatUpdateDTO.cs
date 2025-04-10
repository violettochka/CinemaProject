using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Seat
{
    public class SeatUpdateDTO
    {
        public SeatAvailability? SeatAvailability { get; set; }
        public SeatType? SeatType { get; set; }
    }
}
