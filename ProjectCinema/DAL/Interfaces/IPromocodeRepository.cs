using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IPromocodeRepository : IGenericRepository<Promocode>
    {
        Task<IEnumerable<Booking>> GetBookingsByPromocodeIdAsync(int id);
        //Task<List<Promocode>> GetPromocodesAsync(PromocodeType? promocodeType = null);
    }
}
