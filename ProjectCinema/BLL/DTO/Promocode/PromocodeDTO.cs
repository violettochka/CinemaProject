using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Promocode
{
    public class PromocodeDTO
    {
        public int PromocodeId { get; set; }
        public string? UniqueCode { get; set; }
        public PromocodeType PromocodeType { get; set; }
        public Decimal PromocodeAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
