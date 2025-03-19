using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Cinema
{
    public class CinemaCreateDTO
    {
        [StringLength(256, MinimumLength = 2)]
        [Required]
        public string? CinemaName { get; set; }
        [StringLength(256, MinimumLength = 2)]
        [Required]
        public string? Location { get; set; }

    }
}
