using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.Repositories.Classes
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AplicationDBContext context) : base(context)
        {
        }

        public async Task<Booking?> GetBookingByPaymentAsync(int id)
        {
            return await _dbContext.Bookings
                    .FirstOrDefaultAsync(b => b.PaymentId == id);
        }
    }
}
