using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Cinema
{
    public class CinemaCreateDTO
    {
        public required string CinemaName { get; set; }
        public required string Location { get; set; }

    }
}
