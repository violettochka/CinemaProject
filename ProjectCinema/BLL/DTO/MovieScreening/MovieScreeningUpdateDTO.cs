using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.MovieScreening
{
    public class MovieScreeningUpdateDTO
    {
        public int MovieScreeningId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public MovieScreeningRelevance MovieScreeningRelevance { get; set; }
    }
}
