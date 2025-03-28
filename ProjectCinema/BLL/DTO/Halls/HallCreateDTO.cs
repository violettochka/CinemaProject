using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Halls
{
    public class HallCreateDTO
    {

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string? HallName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        public int CinemaId { get; set; }
    }
}
