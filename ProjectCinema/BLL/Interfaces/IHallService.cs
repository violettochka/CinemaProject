using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IHallService : IGenericService<HallDTO, Hall>
    {
        Task<HallDetailsDTO> GetHallDetailsAsync(int hallId);
        Task<HallDTO> CreateHallAsync(HallCreateDTO hallCreateDTO);
        Task<HallDTO> UpdateHallAsync(HallUpdateDTO hallUpdateDTO, int hallId);
        Task <IEnumerable<HallDTO>> GetHallsByCinemaIdAsync (int cinemaId);
        Task<IEnumerable<HallDTO>> GetHallsByAvailiabilityAsync(HallAvailability hallAvailability);
    }
}
