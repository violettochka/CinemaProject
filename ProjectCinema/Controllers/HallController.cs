using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Enums;

namespace ProjectCinema.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HallController : ControllerBase
    {

        private readonly IHallService _hallService;
        private readonly IValidator<HallCreateDTO> _createHallValidator;
        private readonly IValidator<HallUpdateDTO> _updateHallValidator;
        public HallController(IHallService hallService,
                              IValidator<HallCreateDTO> createHallValidator,
                              IValidator<HallUpdateDTO> updateHallValidator)
        {
            _hallService = hallService;
            _createHallValidator = createHallValidator;
            _updateHallValidator = updateHallValidator;
        }

        [HttpGet("all-halls")]
        public async Task<ActionResult<IEnumerable<HallDTO>>> GetHallsAsync()
        {

            IEnumerable<HallDTO> hallDTOs = await _hallService.GetAllAsync();

            return Ok(hallDTOs);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HallDTO>>> GetHallsByAvailibilityAsync([FromQuery] HallAvailability hallAvailability)
        {
            IEnumerable<HallDTO> availibleHallDTOs = await _hallService.GetHallsByAvailiabilityAsync(hallAvailability);

            return Ok(availibleHallDTOs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<HallDTO>> GetHallByIdAsync([FromRoute(Name = "Id")] int hallId)
        {
            try
            {
                HallDTO hallDTO = await _hallService.GetByIdAsync(hallId);

                return Ok(hallDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpGet("details/{Id}")]
        public async Task<ActionResult<HallDTO>> GetHallDetailsByIdAsync([FromRoute(Name = "Id")] int hallId)
        {
            try
            {
                HallDetailsDTO hallDTO = await _hallService.GetHallDetailsAsync(hallId);

                return Ok(hallDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message});
            }
        }

        [HttpGet("by-cinema/{Id}")]
        public async Task<ActionResult<IEnumerable<HallDTO>>> GetHallsByCinemaIdAsync([FromRoute(Name = "Id")] int cinemaId)
        {
            try
            {
                IEnumerable<HallDTO> hallDTOsByCinemaId = await _hallService.GetHallsByCinemaIdAsync(cinemaId);

                return Ok(hallDTOsByCinemaId);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<HallDTO>> CreateHallAsync([FromBody] HallCreateDTO hallCreateDTO)
        {
            var validResult = _createHallValidator.Validate(hallCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            HallDTO hallDTO = await _hallService.CreateHallAsync(hallCreateDTO);

            return Ok(hallDTO);

        }

        [HttpPatch("update")]
        public async Task<ActionResult<HallDTO>> UpdateHallAsync([FromBody] HallUpdateDTO hallUpdateDTO,
                                                                 [FromRoute(Name = "Id")] int hallId)
        {
            var validResult = _updateHallValidator.Validate(hallUpdateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            HallDTO hallDTO = await _hallService.UpdateHallAsync(hallUpdateDTO, hallId);

            return Ok(hallId);
        }

    }
}
