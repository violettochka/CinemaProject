using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Movie
{
    public class MovieCreateDTO
    {

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string MovieName { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int DurationInMinutes { get; set; }
        [Range(0, 21)]
        [Required]
        public int AgeRestriction { get; set; }
        [Required]
        public DateOnly ReleaseYear { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string Genre { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Language { get; set; }
        [StringLength(256, MinimumLength = 1)]
        public string? ProductionStudio { get; set; }
        [StringLength(256, MinimumLength = 1)]
        public string? Director { get; set; }
        public string? MainCast { get; set; }
    }
}
