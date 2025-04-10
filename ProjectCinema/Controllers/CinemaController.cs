using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Validations.MovieValidation;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IValidator<CinemaCreateDTO> _createCinemaValidator;
        private readonly IValidator<CinemaUpdateDTO> _updateCinemaValidator;

        public CinemaController(ICinemaService cinemaService,
                                IValidator<CinemaCreateDTO> createCinemaValidator,
                                IValidator<CinemaUpdateDTO> updateCinemaValidator)
        {
             
            _cinemaService = cinemaService;
            _createCinemaValidator = createCinemaValidator;
            _updateCinemaValidator = updateCinemaValidator;

        }

        [HttpGet("cinemas")]
        public async Task<ActionResult<IEnumerable<CinemaDTO>>> GetCinemasAsync()
        {
            IEnumerable<CinemaDTO> cinemaDTOs = await _cinemaService.GetAllAsync();

            return Ok(cinemaDTOs);
        }

        [HttpGet("details/{Id}")]
        public async Task<ActionResult<CinemaDetailsDTO>> GetCinemaDetailsByIdAsync([FromRoute(Name = "Id")] int cinemaId)
        {
            try
            {
                CinemaDetailsDTO cinemaDetailsDTO = await _cinemaService.GetCinemaDetailsAsync(cinemaId);

                return Ok(cinemaDetailsDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CinemaDTO>> GetCinemaByIdAsync([FromRoute(Name = "Id")] int cinemaId)
        {
            try
            {
                CinemaDTO cinemaDTO = await _cinemaService.GetByIdAsync(cinemaId);

                return Ok(cinemaDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<CinemaDTO>> CreateCinemaAsync([FromBody] CinemaCreateDTO cinemaCreateDTO)
        {

            var validResult = _createCinemaValidator.Validate(cinemaCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new 
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            CinemaDTO cinema = await _cinemaService.CreateAsync(cinemaCreateDTO);

            return Ok(cinema);
        }

        public async Task<ActionResult<CinemaDTO>> UpdateCinemaAsync([FromRoute(Name = "Id")] int cinemaId, 
                                                                     [FromBody] CinemaUpdateDTO cinemaUpdateDTO)
        {

            var validResult = _updateCinemaValidator.Validate(cinemaUpdateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            try
            {
                CinemaDTO cinemaDTO = await _cinemaService.UpdateAsync(cinemaId, cinemaUpdateDTO);

                return Ok(cinemaDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }


        }
    }
}
