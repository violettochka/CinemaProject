using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.BLL.Interfaces;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocodeController : ControllerBase
    {
        private readonly IPromocodeService _promocodeService;
        private readonly IValidator<PromocodeCreateDTO> _createPromocodeValidator;
        private readonly IValidator<PromocodeUpdateDTO> _updatePromocodeValidator;
        public PromocodeController(IPromocodeService promocodeService, 
                                   IValidator<PromocodeUpdateDTO> updatePromocodeValidator, 
                                   IValidator<PromocodeCreateDTO> createPromocodeValidator)
        {
            _promocodeService = promocodeService;
            _updatePromocodeValidator = updatePromocodeValidator;
            _createPromocodeValidator = createPromocodeValidator;
        }

        [HttpGet("allPromocodes")]
        public async Task<ActionResult<IEnumerable<PromocodeDTO>>> GetPromocodesAsync()
        {
            IEnumerable<PromocodeDTO> promocodeDTOs = await _promocodeService.GetAllAsync();

            return Ok(promocodeDTOs);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromocodeDTO>>> GetPromocodesByActivityAsync([FromQuery] bool isActive)
        {
            IEnumerable<PromocodeDTO> promocodeDTOs = await _promocodeService.GetPromocodesByActivityAsync(isActive);

            return Ok(promocodeDTOs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PromocodeDTO>> GetPromocodeByIdAsync([FromRoute(Name = "Id")] int promocodeId)
        {
            try
            {

                PromocodeDTO promocodeDTO = await _promocodeService.GetByIdAsync(promocodeId);

                return Ok(promocodeDTO);
            }

            catch(KeyNotFoundException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            catch (Exception ex)
            {
                return BadRequest(new {error =ex.Message});
            }


        }

        [HttpGet("details/{Id}")]
        public async Task<ActionResult<PromocodeDTO>> GetPromocodeDetailsByIdAsync([FromRoute(Name = "Id")] int promocodeId)
        {
            try
            {
                PromocodeDetailsDTO promocodeDTO = await _promocodeService.GetPromocodeDetailsByIdAsync(promocodeId);

                return Ok(promocodeDTO);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }

        }

        [HttpPost("create")]
        public async Task<ActionResult<PromocodeDTO>> CreatePromocodeAsync([FromBody] PromocodeCreateDTO promocodeCreateDTO)
        {
            var validResult = _createPromocodeValidator.Validate(promocodeCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            try
            {
                PromocodeDTO promocodeDTO = await _promocodeService.CreatePromocodeAsync(promocodeCreateDTO);

                return Ok(promocodeDTO);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { error = ex.Message });

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = ex.Message });

            }

        }

        public async Task<ActionResult<PromocodeDTO>> UpdatePromocodeAsync([FromRoute(Name = "Id")] int promocodeId, 
                                                                          [FromBody] PromocodeUpdateDTO promocodeUpdateDTO)
        {

            var validResult = _updatePromocodeValidator.Validate(promocodeUpdateDTO);

            if(!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage,
                }));
            }

            try
            {
                PromocodeDTO promocodeDTO = await _promocodeService.UpdatePromocodeAsync(promocodeUpdateDTO, promocodeId);

                return Ok(promocodeDTO);

            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new {error =  ex.Message});
            }
            catch(Exception ex)
            {
                return BadRequest(new {eroor = ex.Message});
            }

        }

    }
}
