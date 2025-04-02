using AutoMapper;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ProjectCinema.BLL.Services
{
    public class CinemaService : GenericService<CinemaDTO, Cinema>, ICinemaService
    {

        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMovieScreeningService _movieScreeningService;
        private readonly IHallService _hallService;
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, 
                            IMovieScreeningService movieScreeningService,
                            IHallService hallService, 
                            IMapper mapper)
                            :base(cinemaRepository, mapper)
        {

            _cinemaRepository = cinemaRepository;
            _movieScreeningService = movieScreeningService;
            _hallService = hallService;
            _mapper = mapper;

        }
        public async Task<CinemaDTO> CreateAsync(CinemaCreateDTO cinemaDTO)
        {

            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            cinema.CreatedAt = DateTime.Now;
            await _cinemaRepository.AddAsync(cinema);
            await _cinemaRepository.SaveAsync();

            return _mapper.Map<CinemaDTO>(cinema);

        }

        public async Task<CinemaDetailsDTO> GetCinemaDetailsAsync(int id)
        {

            Cinema? cinema = await _cinemaRepository.GetByIdAsync(id);

            if(cinema == null)
            {
                throw new InvalidOperationException($"Cinema with id equals {id} does not exists");
            }
            
            IEnumerable<MovieScreeningDTO> movieScreeings = await _movieScreeningService.GetScreeningsByCinemaIdAsync(id);
            IEnumerable<HallDTO> halls = await _hallService.GetHallsByCinemaIdAsync(id);

            CinemaDetailsDTO cinemaDTO = _mapper.Map<CinemaDetailsDTO>(cinema);
            cinemaDTO.MovieScreenings = _mapper.Map<List<MovieScreeningDTO>>(movieScreeings);
            cinemaDTO.Halls = halls.ToList();

            return cinemaDTO;
        }

        public async Task<CinemaDTO> UpdateAsync(int id, CinemaDTO cinemaDTO)
        {

            Cinema? cinema = await _cinemaRepository.GetByIdAsync(id);

            if (cinema == null)
            {
                throw new InvalidOperationException($"Cinema with id equals {id} does not exists");
            }

            _mapper.Map(cinemaDTO, cinema);
            await _cinemaRepository.UpdateAsync(cinema);
            await _cinemaRepository.SaveAsync();

            return _mapper.Map<CinemaDTO>(cinema);

        }

    }
}
