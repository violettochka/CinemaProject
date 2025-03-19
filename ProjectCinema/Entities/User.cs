using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public UserRole UserRole { get; set; }

        public DateOnly DateOfBirth { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
