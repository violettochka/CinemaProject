using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Promocode
{
    public class PromocodeCreateDTO
    {
        public required string UniqueCode { get; set; }
        public PromocodeType PromocodeType { get; set; }
        public decimal PromocodeAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Condition { get; set; }
    }
}
