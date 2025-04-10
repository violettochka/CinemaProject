using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Row;

namespace ProjectCinema.BLL.DTO.Seat
{
    public class SeatDTO
    {
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public SeatAvailability SeatAvailability { get; set; }
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public RowDTO? Row {  get; set; }

    }
}
