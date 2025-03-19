using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Users
{
    public class UserUpdateDTO
    {
        public int UserId { get; set; }
        [StringLength(256, MinimumLength = 2)]
        public string? FirstName { get; set; }
        [StringLength(256, MinimumLength = 2)]
        public string? LastName { get; set; }
        [StringLength(256, MinimumLength = 2)]
        public string? Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
