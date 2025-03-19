using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IShowTimeRepository: IGenericRepository<ShowTime>
    {
        Task<IEnumerable<Ticket>> GetTicketsByShowTimeAsync(int id);
        Task<IEnumerable<ShowTime>> GetShowTimesAsync(ShowTimeStatus? showTimeStatus = null);
    }
}
