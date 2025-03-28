using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.Interfaces
{
    public interface ITicketService : IGenericService<TicketDTO, Ticket>
    {
        Task<TicketDTO> CreateTicketAsync(TicketCreateDTO ticket);
        Task<TicketDTO> UpdateTicketAsync(TicketUpdateDTO ticket, int ticketId);
        Task<IEnumerable<TicketDTO>> GetTicketsByTicketStatusAsync(TicketStatus ticketStatus);  
        Task<IEnumerable<TicketDTO>> GetTicketsByBookingIdAsync(int bookingId);
        Task<IEnumerable<TicketDTO>> GetTicketsByShowTimeIdAsync(int shoeTimeId);
        Task<IEnumerable<TicketDTO>> GetTicketsBySeatIdAsync(int seatId);
    }
}
