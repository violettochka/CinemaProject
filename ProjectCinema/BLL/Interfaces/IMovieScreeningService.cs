using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IMovieScreeningService : IGenericService<MovieScreeningDTO, MovieScreening>
    {
        Task<IEnumerable<MovieScreeningDTO>> GetMovieScreeningsByRelevanceAsync(MovieScreeningRelevance relevance);
        Task<MovieScreeningDTO> CreateAsync(MovieScreeningCreateDTO screeningDTO); 
        Task<MovieScreeningDTO> UpdateAsync(int id, MovieScreeningUpdateDTO screeningDTO);
        Task<IEnumerable<MovieScreeningDTO>> GetScreeningsByCinemaIdAsync(int cinemaId);
        Task<IEnumerable<MovieScreeningDTO>> GetMovieSreeningsByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieScreeningDetailsDTO>> GetScreeningsDetailsByMovieIdAsync(int movieId);

    }
}
