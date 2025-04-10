using ProjectCinema.BLL.DTO.MovieScreening;

namespace ProjectCinema.BLL.Interfaces.IMovieScreeningServices
{
    public interface IMovieScreeningValidationService
    {
        Task<bool> IsMovieScreeningExistsByCinemaAndMovieAsync(int cinemaId, int movieId);
        Task<IEnumerable<MovieScreeningDTO>> GetOverlappingScreeningsAsync(int cinemaId, DateTime startTime, DateTime endTime);
    }
}
