using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Promocode
{
    public class PromocodeUpdateDTO
    {
        public string? UniqueCode { get; set; }
        [Required]
        public PromocodeType PromocodeType { get; set; }
        public decimal? PromocodeAmount { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Condition { get; set; }
    }
}
