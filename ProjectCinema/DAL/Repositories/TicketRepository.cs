using ProjectCinema.Data;
using ProjectCinema.Entities;

namespace ProjectCinema.Repositories.Classes
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository(AplicationDBContext context) : base(context)
        {
        }
    }
}
