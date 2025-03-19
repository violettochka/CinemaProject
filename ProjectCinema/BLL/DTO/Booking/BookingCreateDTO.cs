using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Booking
{
    public class BookingCreateDTO
    {

        [Required]
        public int UserId { get; set; }

        public int? PaymentId { get; set; }
        public int? PromocodeId { get; set; }
    }
}
