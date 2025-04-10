using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces.IMovieScreeningServices;
using ProjectCinema.Enums;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieScreeningController : ControllerBase
    {
        private readonly IMovieScreeningCrudService _movieScreeningCrudService;
        private readonly IMovieScreeningQueryService _movieScreeningQueryService;
        private readonly IValidator<MovieScreeningCreateDTO> _movieScreeningCreateValidator;
        private readonly IValidator<MovieScreeningUpdateDTO> _movieScreeningUpdateValidator;

        public MovieScreeningController(IMovieScreeningCrudService movieScreeningCrudService,
                                        IMovieScreeningQueryService movieScreeningQueryService,
                                        IValidator<MovieScreeningCreateDTO> movieScreeningCreateValidator,
                                        IValidator<MovieScreeningUpdateDTO> movieScreeningUpdateValidator)
        {
            _movieScreeningCrudService = movieScreeningCrudService;
            _movieScreeningQueryService = movieScreeningQueryService;
            _movieScreeningCreateValidator = movieScreeningCreateValidator;
            _movieScreeningUpdateValidator = movieScreeningUpdateValidator;
        }

        [HttpGet("all-movie-screening")]
        public async Task<ActionResult<IEnumerable<MovieScreeningDTO>>> GetMovieScreeningsAsync()
        {
            IEnumerable<MovieScreeningDTO> movieScreeningDTOs = await _movieScreeningCrudService.GetAllAsync();

            return Ok(movieScreeningDTOs);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieScreeningDTO>>> GetMovieScreeningsByRelevanceAsync(
                                                                        [FromQuery] MovieScreeningRelevance movieScreeningRelevance)
        {
            try
            {
                IEnumerable<MovieScreeningDTO> movieScreeningDTOs = await _movieScreeningQueryService
                                                                    .GetMovieScreeningsByRelevanceAsync(movieScreeningRelevance);

                return Ok(movieScreeningDTOs);
            }
            catch (ArgumentException ex)
            { 
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<MovieScreeningDTO>> GetMovieScreningByIdAsync([FromRoute(Name = "Id")] int movieScreeingId)
        {
            try
            {
                MovieScreeningDTO movieScreeningDTO = await _movieScreeningCrudService.GetByIdAsync(movieScreeingId);

                return Ok(movieScreeningDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("by-movie/{Id}")]
        public async Task<ActionResult<MovieScreeningDTO>> GetMovieScreeningsByMovieIdAsync([FromRoute(Name = "Id")] int movieId)
        {
            try
            {
                IEnumerable<MovieScreeningDTO> movieScreeningDTOs = await _movieScreeningQueryService.GetMovieSreeningsByMovieIdAsync(movieId);

                return Ok(movieScreeningDTOs);
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

        [HttpGet("details/by-movie{Id}")]
        public async Task<ActionResult<IEnumerable<MovieScreeningDetailsDTO>>> GetScreeningsDetailsByMovieIdAsync([FromRoute(Name = "Id")] int movieId)
        {
            try
            {
                IEnumerable<MovieScreeningDetailsDTO> movieScreeningDTO = await _movieScreeningQueryService.GetScreeningsDetailsByMovieIdAsync(movieId);

                return Ok(movieScreeningDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public async Task<ActionResult<MovieScreeningDTO>> CreateMovieScreeningAsync([FromBody] MovieScreeningCreateDTO movieScreeningCreateDTO)
        {
            var validResult = await _movieScreeningCreateValidator.ValidateAsync(movieScreeningCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            MovieScreeningDTO movieScreeningDTO = await _movieScreeningCrudService.CreateAsync(movieScreeningCreateDTO);

            return Ok(movieScreeningDTO);
        }

        [HttpPatch("update/{Id}")]
        public async Task<ActionResult<MovieScreeningDTO>> UpdateMovieScreeningAsync([FromBody] MovieScreeningUpdateDTO movieScreeningUpdateDTO,
                                                                                     [FromRoute(Name = "Id")] int movieScreeingId)
        {
            var validResult = await _movieScreeningUpdateValidator.ValidateAsync(movieScreeningUpdateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            MovieScreeningDTO movieScreeningDTOUpdated = await _movieScreeningCrudService.UpdateAsync(movieScreeingId, movieScreeningUpdateDTO);

            return Ok(movieScreeningDTOUpdated);
        }
    }
}
