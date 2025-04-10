using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.BLL.DTO.Row;

namespace ProjectCinema.BLL.DTO.Seat
{
    public class SeatDetailsDTO
    {

        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public SeatAvailability SeatAvailability { get; set; }
        public SeatType SeatType { get; set; }
        public RowDTO? Row { get; set; }
        public ICollection<TicketDTO>? Tickets { get; set; }
    }
}
