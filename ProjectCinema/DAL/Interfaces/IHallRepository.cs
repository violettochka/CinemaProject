using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IHallRepository : IGenericRepository<Hall>
    {
        Task<IEnumerable<ShowTime>> GetShowTimesByHallIdAsync(int id);
        Task<IEnumerable<Seat>> GetSeatByHallIdAsync(int id);
        Task<IEnumerable<Hall>> GetHAllsByCinemaIdAsync(int cinemaId);
    }
}
