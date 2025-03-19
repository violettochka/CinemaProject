using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Halls
{
    public class HallUpdateDTO
    {
        public int HallId { get; set; }
        [StringLength(256, MinimumLength = 2)]
        public string? HallName { get; set; }
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public HallAvailability HallAvailability { get; set; }
    }
}
