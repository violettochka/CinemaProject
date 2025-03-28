using AutoMapper;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class GenericService<TDTO, TEntity> : IGenericService<TDTO, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> entity, IMapper mapper)
        {

            _genericRepository = entity;
            _mapper = mapper;

        }
        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {

            IEnumerable<TEntity> entities = await _genericRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TDTO>>(entities);

        }

        public async Task<TDTO> GetByIdAsync(int entityId)
        {

            TEntity etity = await _genericRepository.GetByIdAsync(entityId);

            return _mapper.Map<TDTO>(etity);

        }
    }
}
