using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync (int id);
    }
}
