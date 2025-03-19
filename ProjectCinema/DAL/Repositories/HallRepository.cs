using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
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
            return await _dbContext.Halls.Where(h => h.CinemaId ==  cinemaId).ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetSeatByHallIdAsync(int id)
        {
            return await _dbContext.Seats.Where(s => s.HallId == id).ToListAsync();
        }

        public async Task<IEnumerable<ShowTime>> GetShowTimesByHallIdAsync(int id)
        {
            return await _dbContext.ShowTimes.Where(s => s.HallId == id).ToListAsync();
        }
    }
}
