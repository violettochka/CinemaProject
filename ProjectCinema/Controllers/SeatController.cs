using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.Interfaces;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        private readonly IValidator<SeatCreateDTO> _createSeatValidator;
        private readonly IValidator<SeatUpdateDTO> _updateSeatValidator;
        public SeatController(ISeatService seatService, 
                              IValidator<SeatUpdateDTO> updateSeatValidator, 
                              IValidator<SeatCreateDTO> createSeatValidator)
        {
            _seatService = seatService;
            _updateSeatValidator = updateSeatValidator;
            _createSeatValidator = createSeatValidator;
        }

        [HttpGet("all-seats")]
        public async Task<ActionResult<IEnumerable<SeatDTO>>> GetSeatsAsync()
        {
            IEnumerable<SeatDTO> seatDTOs  = await _seatService.GetAllAsync();

            return Ok(seatDTOs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SeatDTO>> GetSeatByIdAsync([FromRoute(Name = "Id")] int seatId)
        {
            try
            {
                SeatDTO seatDTO = await _seatService.GetByIdAsync(seatId);

                return Ok(seatDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("details/{Id}")]
        public async Task<ActionResult<SeatDTO>> GetSeatDetailsByIdAsync([FromRoute(Name = "Id")] int seatId)
        {
            try
            {
                SeatDetailsDTO seatDetailsDTO = await _seatService.GetSeatDetailsAsync(seatId);

                return Ok(seatDetailsDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("by-row/{Id}")]
        public async Task<ActionResult<IEnumerable<SeatDTO>>> GetSeatsByRowId([FromRoute(Name = "Id")] int rowId)
        {
            IEnumerable<SeatDTO> seatDTOs = await _seatService.GetSeatsByRowIdAsync(rowId);

            return Ok(seatDTOs);
        }

        [HttpPost("create")]
        public async Task<ActionResult<SeatDTO>> CreateSeatAsync([FromBody] SeatCreateDTO seatCreateDTO)
        {
            var validResult = await _createSeatValidator.ValidateAsync(seatCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            SeatDTO seatDTO = await _seatService.CreateSeatAsync(seatCreateDTO);

            return Ok(seatDTO);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<SeatDTO>> UpdateSeatAsync([FromBody] SeatUpdateDTO seatUpdateDTO, [FromRoute] int seatId)
        {
            var validResult = _updateSeatValidator.Validate(seatUpdateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            SeatDTO seatDTO = await _seatService.UpdateSeatAsync(seatUpdateDTO, seatId);

            return Ok(seatDTO);
        }
    }
}
