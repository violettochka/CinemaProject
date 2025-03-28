using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int id)
        {

            return await _dbContext.Halls.AsNoTracking().Where(h => h.CinemaId == id).ToListAsync();

        }
    }
}
