using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class PromocodeRepository : GenericRepository<Promocode>, IPromocodeRepository
    {
        public PromocodeRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPromocodeIdAsync(int id)
        {
            return await _dbContext.Bookings.AsNoTracking().Where(b => b.PromocodeId == id).ToListAsync();
        }

        public async Task<Promocode> GetPromocodeByUniqueCodeAsync(string uniqueCode)
        {
            return await _dbContext.Promocodes.FirstOrDefaultAsync(uc => uc.UniqueCode == uniqueCode);
        }

        //public Task<List<Promocode>> GetPromocodesAsync(PromocodeType? promocodeType = null)
        //{
        //    var query = _dbSet.AsQueryable();
        //    if (promocodeType.HasValue)
        //    {
        //        query = query.Where(p => p.PromocodeType)
        //    }
        //}

        public async Task<IEnumerable<Promocode>> GetPromocodesByActivityAsync(bool isActive)
        {
            return await _dbContext.Promocodes.AsNoTracking().Where(p => p.IsActive == isActive).ToListAsync();
        }
    }
}

