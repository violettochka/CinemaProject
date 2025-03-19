using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.Cinema;

namespace ProjectCinema.BLL.DTO.MovieScreening
{
    public class MovieScreeningDTO
    {
        public int MovieScreeningId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public MovieDTO? Movie { get; set; }
        public CinemaDTO? Cinema { get; set; }

    }
}
