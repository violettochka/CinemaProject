using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.ShowTime;

namespace ProjectCinema.BLL.DTO.MovieScreening
{
    public class MovieScreeningDetailsDTO
    {
        public int MovieScreeningId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieScreeningRelevance MovieScreeningRelevance { get; set; }
        public MovieDTO? Movie { get; set; }
        public int MovieId { get; set; }
        public CinemaDTO? Cinema { get; set; }
        public ICollection<ShowTimeDTO>? ShowTimes { get; set; }
    }
}
