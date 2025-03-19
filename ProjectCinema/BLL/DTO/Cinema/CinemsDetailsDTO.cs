using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.DTO.Halls;

namespace ProjectCinema.BLL.DTO.Cinema
{
    public class CinemsDetailsDTO
    {
        public int CinemaId { get; set; }
        public string? CinemaName { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<MovieScreeningDTO>? MovieScreenings { get; set; }
        public ICollection<HallDTO>? Halls { get; set; }
    }
}
