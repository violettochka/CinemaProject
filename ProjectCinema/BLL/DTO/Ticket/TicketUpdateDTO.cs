using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Ticket
{
    public class TicketUpdateDTO
    {
        public int TicketId { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public Decimal PriceAtPurchase { get; set; }
    }
}
