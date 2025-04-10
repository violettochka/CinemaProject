using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces.IMovieScreeningServices
{
    public interface IMovieScreeningCrudService : IGenericService<MovieScreeningDTO, MovieScreening>
    {
        Task<MovieScreeningDTO> CreateAsync(MovieScreeningCreateDTO screeningDTO);
        Task<MovieScreeningDTO> UpdateAsync(int id, MovieScreeningUpdateDTO screeningDTO);
    }
}
