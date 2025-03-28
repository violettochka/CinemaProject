using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IPromocodeService : IGenericService<PromocodeDTO, Promocode>
    {
        Task<PromocodeDetailsDTO> GetPromocodeDetailsByIdAsync(int promocodeId);
        Task<PromocodeDTO> CreatePromocodeAsync(PromocodeCreateDTO promocodeCreateDTO);
        Task<PromocodeDTO> UpdatePromocodeAsync(PromocodeUpdateDTO promocodeUpdateDTO, int promocodeId);
        Task<IEnumerable<PromocodeDTO>> GetPromocodesByActivityAsync(bool isActive);

    }
}
