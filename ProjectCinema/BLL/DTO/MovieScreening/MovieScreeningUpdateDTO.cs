using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.MovieScreening
{
    public class MovieScreeningUpdateDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public MovieScreeningRelevance? MovieScreeningRelevance { get; set; }
    }
}
