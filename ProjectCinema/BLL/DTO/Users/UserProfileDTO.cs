using ProjectCinema.BLL.DTO.Booking;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Users
{
    public class UserProfileDTO
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<BookingDTO>? Bookings { get; set; }
    }
}
