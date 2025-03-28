using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface ICinemaService : IGenericService<CinemaDTO, Cinema>
    {
        Task<CinemaDetailsDTO> GetCinemaDetailsAsync(int id);
        Task<CinemaDTO> CreateAsync(CinemaCreateDTO cinemaDTO);
        Task<CinemaDTO> UpdateAsync(int id, CinemaDTO cinemaDTO);
    }
}
