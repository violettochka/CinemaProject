using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Payment
{
    public class PaymentUpdateDTO
    {
        public PaymentMethod? PeymentMethod { get; set; }
        
    }
}
