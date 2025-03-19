using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {
        Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int id);
    }
}
