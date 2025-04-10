using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.BLL.Interfaces;

namespace ProjectCinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RowController : ControllerBase
    {
        private readonly IRowService _rowService;
        private readonly IValidator<RowCreateDTO> _createRowValidator;
        private readonly IValidator<RowUpdateDTO> _updateRowValidator;

        public RowController(IRowService rowService, 
                             IValidator<RowUpdateDTO> updateRowValidator, 
                             IValidator<RowCreateDTO> createRowValidator)
        {
            _rowService = rowService;
            _updateRowValidator = updateRowValidator;
            _createRowValidator = createRowValidator;
        }

        [HttpGet("all-rows")]
        public async Task<ActionResult<IEnumerable<RowDTO>>> GetRowsAsync()
        {
            IEnumerable<RowDTO> rowDTOs = await _rowService.GetAllAsync();

            return Ok(rowDTOs);
        }

        [HttpGet("by-hall/{Id}")]
        public async Task<ActionResult<IEnumerable<RowDTO>>> GetRowsByHallIdAsync([FromRoute(Name = "Id")] int hallId)
        {
            IEnumerable<RowDTO> rowDTOs = await _rowService.GetRowsByHallIdAsync(hallId);

            return Ok(rowDTOs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RowDTO>> GetRowByIdAsync([FromRoute(Name = "Id")] int rowId)
        {
            try
            {
                RowDTO rowDTO = await _rowService.GetByIdAsync(rowId);

                return Ok(rowDTO);
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
        public async Task<ActionResult<RowDetailsDTO>> GetRowDetailsByIdAsync([FromRoute(Name = "Id")] int rowId)
        {
            try
            {
                RowDetailsDTO rowDetailsDTO = await _rowService.GetRowDetailsByIdAsync(rowId);

                return Ok(rowDetailsDTO);
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

        [HttpPost("create")]
        public async Task<ActionResult<RowDTO>> CreateRowAsync([FromBody] RowCreateDTO rowCreateDTO)
        {
            var validResult = await _createRowValidator.ValidateAsync(rowCreateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            RowDTO rowDTO = await _rowService.CreateRowAsync(rowCreateDTO);

            return Ok(rowDTO);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<RowDTO>> UpdateRowAsync([FromBody] RowUpdateDTO rowUpdateDTO, [FromRoute] int rowId)
        {
            var validResult = await _updateRowValidator.ValidateAsync(rowUpdateDTO);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            RowDTO rowDTO = await _rowService.UpdateRowAsync(rowUpdateDTO, rowId);

            return Ok(rowDTO);
        }
    }
}
