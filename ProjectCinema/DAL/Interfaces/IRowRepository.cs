using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.DAL.Interfaces
{
    public interface IRowRepository : IGenericRepository<Row>
    {
        Task<IEnumerable<Row>> GetRowsByHallIdAsync(int hallId);
    }
}
