using AutoMapper;
using ProjectCinema.BLL.DTO.Booking;
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
        private readonly IBookingService _bookingService;
        public PaymentService(IPaymentRepository paymanentRepository, 
                              IMapper mapper,
                              IBookingService bookingService) : base(paymanentRepository, mapper)
        {
            _paymanentRepository = paymanentRepository;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public async Task<PaymentDTO> CreatePaymentAsync(PaymentCreateDTO paymentCreateDTO)
        {

            BookingDTO booking = await _bookingService.GetByIdAsync(paymentCreateDTO.BookingId);

            if(booking == null)
            {
                throw new Exception($"The specified booking was not found");
            }

            if (!Enum.IsDefined(typeof(PaymentMethod), paymentCreateDTO.PeymentMethod))
            {
                throw new ArgumentException("The specified payment method is incorrect.");
            }

            Payment existingPayment = await _paymanentRepository.GetByIdAsync(paymentCreateDTO.BookingId);

            if (existingPayment != null && existingPayment.PaymentStatus == PaymentStatus.Success)
            {
                throw new InvalidOperationException("There is already a successful payment for this booking.");
            }

            if(paymentCreateDTO.AmountPaid != booking.TotalPrice)
            {
                throw new ArgumentException($"Payment amount ({paymentCreateDTO.AmountPaid}) must match the booking amount ({booking.TotalPrice}).");
            }

            Payment payment = _mapper.Map<Payment>(paymentCreateDTO);
            payment.PaymentStatus = PaymentStatus.Success;
            payment.PaidAt = DateTime.Now;

            await _paymanentRepository.AddAsync(payment);
            await _paymanentRepository.SaveAsync();

            return _mapper.Map<PaymentDTO>(payment);

        }

        public async Task<PaymentDetailsDTO> GetPaymentDetailsByIdAsync(int paymentId)
        {
            if(await _paymanentRepository.GetByIdAsync(paymentId) == null)
            {
                throw new Exception($"Paynemt with id equal {paymentId} does not exists");
            }

            Payment payment = await _paymanentRepository.GetByIdAsync(paymentId);

            return _mapper.Map<PaymentDetailsDTO>(payment);
        }

        public async Task<PaymentDTO> UpdatePaymentAsync(PaymentUpdateDTO paymentUpdateDTO, int paymentId)
        {

            if (await _paymanentRepository.GetByIdAsync(paymentId) == null)
            {
                throw new Exception($"Paynemt with id equal {paymentId} does not exists");
            }

            Payment payment = await _paymanentRepository.GetByIdAsync(paymentId);
            _mapper.Map(paymentUpdateDTO, payment);

            await _paymanentRepository.UpdateAsync(payment);
            await _paymanentRepository.SaveAsync();

            return _mapper.Map<PaymentDTO>(payment);
        }
    }
}
