using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Booking
{
    public class BookingUpdateDTO
    {
        public int BookingId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
