using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Halls
{
    public class HallUpdateDTO
    {
        public string? HallName { get; set; }
        public int? RowCount { get; set; }
        public HallAvailability? HallAvailability { get; set; }
    }
}
