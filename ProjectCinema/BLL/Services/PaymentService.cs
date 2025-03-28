using AutoMapper;
using ProjectCinema.BLL.DTO.Payment;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class PaymentService : GenericService<PaymentDTO, Payment>, IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymanentRepository;    
        public PaymentService(IPaymentRepository paymanentRepository, IMapper mapper) : base(paymanentRepository, mapper)
        {
            _paymanentRepository = paymanentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> CreatePaymentAsync(PaymentCreateDTO paymentCreateDTO)
        {

            Payment payment = _mapper.Map<Payment>(paymentCreateDTO);
            payment.PaymentStatus = PaymentStatus.Success;
            payment.PaidAt = DateTime.Now;

            await _paymanentRepository.AddAsync(payment);
            await _paymanentRepository.SaveAsync();

            return _mapper.Map<PaymentDTO>(payment);

        }

        public async Task<PaymentDetailsDTO> GetPaymentDetailsByIdAsync(int paymentId)
        {
            Payment payment = await _paymanentRepository.GetByIdAsync(paymentId);

            return _mapper.Map<PaymentDetailsDTO>(payment);
        }

        public async Task<PaymentDTO> UpdatePaymentAsync(PaymentUpdateDTO paymentUpdateDTO, int paymentId)
        {
            Payment payment = await _paymanentRepository.GetByIdAsync(paymentId);
            _mapper.Map(paymentUpdateDTO, payment);

            await _paymanentRepository.UpdateAsync(payment);
            await _paymanentRepository.SaveAsync();

            return _mapper.Map<PaymentDTO>(payment);
        }
    }
}
