using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Booking?> GetBookingByPaymentAsync(int id);
    }
}
