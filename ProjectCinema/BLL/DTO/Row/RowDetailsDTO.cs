using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Seat;

namespace ProjectCinema.BLL.DTO.Row
{
    public class RowDetailsDTO
    {
        public int Id { get; set; }
        public Hall? Hall { get; set; }
        public int RowNumber { get; set; }

        public ICollection<SeatDTO>? Seats { get; set; }
    }
}
