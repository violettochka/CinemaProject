using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IHallRepository : IGenericRepository<Hall>
    {
        Task<IEnumerable<Hall>> GetHAllsByCinemaIdAsync(int cinemaId);
        Task<IEnumerable<Hall>> GetHallsByAviliabilityAsync(HallAvailability? hallAvailability = null);
    }
}
