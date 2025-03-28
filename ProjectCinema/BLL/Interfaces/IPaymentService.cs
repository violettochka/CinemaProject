using ProjectCinema.BLL.DTO.Payment;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IPaymentService : IGenericService<PaymentDTO, Payment>
    {
        Task<PaymentDetailsDTO> GetPaymentDetailsByIdAsync(int paymentId);
        Task<PaymentDTO> CreatePaymentAsync(PaymentCreateDTO paymentCreateDTO);
        Task<PaymentDTO> UpdatePaymentAsync(PaymentUpdateDTO paymentUpdateDTO, int paymentId);
    }
}
