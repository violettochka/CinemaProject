using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Cinema
{
    public class CinemaDTO
    {
        public int CinemaId { get; set; }
        public string? CinemaName { get; set; }
        public string? Location { get; set; }
    }
}
