using Microsoft.EntityFrameworkCore;
using ProjectCinema.DAL.Interfaces;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Classes;

namespace ProjectCinema.DAL.Repositories
{
    public class RowRepository : GenericRepository<Row>, IRowRepository
    {
        public RowRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Row>> GetRowsByHallIdAsync(int hallId)
        {
            return await _dbContext.Rows.AsNoTracking().Where(r => r.HallId == hallId).ToListAsync();
        }
    }
}
    