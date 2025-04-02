using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Ticket;

namespace ProjectCinema.BLL.DTO.ShowTime
{
    public class ShowTimeDetailsDTO
    {
        public int ShowTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ViewingFormat ViewingFormat { get; set; }
        public ShowTimeStatus ShowTimeStatus { get; set; }
        public Decimal TicketPrice { get; set; }
        public ICollection<TicketDTO>? Tickets { get; set; }
        public MovieScreeningDTO? MovieScreening { get; set; }
        public HallDTO? Hall { get; set; }
        public int HallId { get; set; }
        public int MovieScreeningId { get; set; }
    }
}
