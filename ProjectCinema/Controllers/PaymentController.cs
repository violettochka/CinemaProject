using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Payment;
using ProjectCinema.BLL.Interfaces;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IValidator<PaymentCreateDTO> _paymentCreateValidator;
        private readonly IValidator<PaymentUpdateDTO> _paymentUpdateValidator;

        public PaymentController(IPaymentService paymentService,
                                 IValidator<PaymentCreateDTO> paymentCreateValidator,
                                 IValidator<PaymentUpdateDTO> paymentUpdateValidator)
        {
            _paymentService = paymentService;
            _paymentCreateValidator = paymentCreateValidator;
            _paymentUpdateValidator = paymentUpdateValidator;
        }

        [HttpGet("all-payments")]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPaymentsAsync()
        {
            IEnumerable<PaymentDTO> paymentDTOs  = await _paymentService.GetAllAsync();

            return Ok(paymentDTOs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PaymentDTO>> GetPaymentByIdAsync([FromRoute(Name = "Id")] int paymentId)
        {
            PaymentDTO paymentDTO = await _paymentService.GetByIdAsync(paymentId);

            return Ok(paymentDTO);
        }

        [HttpGet("details/{Id}")]
        public async Task<ActionResult<PaymentDetailsDTO>> GetPaymentDetailsByIdAsync([FromRoute(Name = "Id")] int paymentId)
        {
            PaymentDetailsDTO paymentDTO = await _paymentService.GetPaymentDetailsByIdAsync(paymentId);

            return Ok(paymentDTO );
        }

        [HttpPost("create")]
        public async Task<ActionResult<PaymentDTO>> CreatePaymnetAsync([FromBody] PaymentCreateDTO paymentCreateDTO)
        {
            var validResult = await _paymentCreateValidator.ValidateAsync(paymentCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            PaymentDTO paymentDTO = await _paymentService.CreatePaymentAsync(paymentCreateDTO);

            return Ok(paymentDTO);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<PaymentDTO>> UpdatePaymentAsync([FromBody] PaymentUpdateDTO paymentUpdateDTO, [FromRoute(Name = "Id")] int paymentId)
        {
            var validResult =  _paymentUpdateValidator.Validate(paymentUpdateDTO);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            PaymentDTO paymentDTO = await _paymentService.UpdatePaymentAsync(paymentUpdateDTO, paymentId);

            return Ok(paymentDTO);
        }
    }
}
