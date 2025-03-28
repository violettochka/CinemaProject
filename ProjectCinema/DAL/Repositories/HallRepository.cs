using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class HallRepository : GenericRepository<Hall>, IHallRepository
    {
        public HallRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hall>> GetHAllsByCinemaIdAsync(int cinemaId)
        {

            return await _dbContext.Halls.AsNoTracking().Where(h => h.CinemaId ==  cinemaId).ToListAsync();

        }

        public async Task<IEnumerable<Hall>> GetHallsByAviliabilityAsync(HallAvailability? hallAvailability = null)
        {

            var query = _dbSet.AsQueryable();
            if (hallAvailability.HasValue)
            {
                query = query.AsNoTracking().Where(h => h.HallAvailability == hallAvailability.Value);
            }

            return await query.ToListAsync();
        }

    }
}
