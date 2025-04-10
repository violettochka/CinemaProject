using AutoMapper;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class PromocodeService : GenericService<PromocodeDTO, Promocode>, IPromocodeService
    {
        private readonly IMapper _mapper;
        private readonly IPromocodeRepository _promocodeRepository;
        
        public PromocodeService(IPromocodeRepository promocodeRepository, IMapper mapper) : base(promocodeRepository, mapper)
        {

            _mapper = mapper;
            _promocodeRepository = promocodeRepository;

        }

        public async Task<PromocodeDTO> CreatePromocodeAsync(PromocodeCreateDTO promocodeCreateDTO)
        {

            Promocode? existingPromocode = await _promocodeRepository.GetPromocodeByUniqueCodeAsync(promocodeCreateDTO.UniqueCode);

            if (existingPromocode != null)
            {
                throw new ArgumentException("A promocode with this unique code already exists.");
            }

            Promocode promocode = _mapper.Map<Promocode>(promocodeCreateDTO);
            promocode.IsActive = true;
            promocode.CreatedAdt = DateTime.Now;

            await _promocodeRepository.AddAsync(promocode);
            await _promocodeRepository.SaveAsync();

            return _mapper.Map<PromocodeDTO>(promocode);

        }

        public async Task<PromocodeDetailsDTO> GetPromocodeDetailsByIdAsync(int promocodeId)
        {
            if (await _promocodeRepository.GetByIdAsync(promocodeId) == null)
            {
                throw new KeyNotFoundException($"Promocode with id equal {promocodeId} does not exists");
            }

            Promocode promocode = await _promocodeRepository.GetByIdAsync(promocodeId);

            return _mapper.Map<PromocodeDetailsDTO>(promocode);

        }

        public async Task<IEnumerable<PromocodeDTO>> GetPromocodesByActivityAsync(bool isActive)
        {

            IEnumerable<Promocode>? promocode = await _promocodeRepository.GetPromocodesByActivityAsync(isActive);

            return _mapper.Map<IEnumerable<PromocodeDTO>>(promocode);
        }

        public async Task<PromocodeDTO> UpdatePromocodeAsync(PromocodeUpdateDTO promocodeUpdateDTO, int promocodeId)
        {

            if (await _promocodeRepository.GetByIdAsync(promocodeId) == null)
            {
                throw new KeyNotFoundException($"Promocode with id equal {promocodeId} does not exists");
            }

            Promocode promocode = await _promocodeRepository.GetByIdAsync(promocodeId);
            _mapper.Map(promocodeUpdateDTO, promocode);

            await _promocodeRepository.UpdateAsync(promocode);
            await _promocodeRepository.SaveAsync();

            return _mapper.Map<PromocodeDTO>(promocode);

        }
    }
}
