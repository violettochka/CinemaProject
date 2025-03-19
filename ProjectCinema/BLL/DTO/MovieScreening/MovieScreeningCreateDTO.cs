using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Movie;

namespace ProjectCinema.BLL.DTO.MovieScreening
{
    public class MovieScreeningCreateDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CinemaId { get; set; }
    }
}
