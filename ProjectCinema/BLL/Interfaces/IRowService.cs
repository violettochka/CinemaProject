using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IRowService : IGenericService<RowDTO, Row>
    {
        Task<RowDTO> CreateRowAsync(RowCreateDTO rowCreateDTO);
        Task<RowDTO> UpdateRowAsync(RowUpdateDTO rowUpdateDTO, int rowId);
        Task<IEnumerable<RowDTO>> GetRowsByHallIdAsync(int hallId);
        Task<RowDetailsDTO> GetRowDetailsByIdAsync(int rowId);
    }
}
