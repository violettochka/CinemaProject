using AutoMapper;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;
using System.Runtime.InteropServices;

namespace ProjectCinema.BLL.Services
{
    public class CinemaService : GenericService<CinemaDTO, Cinema>, ICinemaService
    {

        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMovieScreeningService _movieScreeningService;
        private readonly IHallRepository _hallRepository;
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, 
                            IMovieScreeningService movieScreeningService,
                            IHallRepository hallRepository, 
                            IMapper mapper)
                            :base(cinemaRepository, mapper)
        {

            _cinemaRepository = cinemaRepository;
            _movieScreeningService = movieScreeningService;
            _hallRepository = hallRepository;
            _mapper = mapper;

        }
        public async Task<CinemaDTO> CreateAsync(CinemaCreateDTO cinemaDTO)
        {

            var cinema = _mapper.Map<Cinema>(cinemaDTO);
            cinema.CreatedAt = DateTime.Now;
            await _cinemaRepository.AddAsync(cinema);
            await _cinemaRepository.SaveAsync();

            return _mapper.Map<CinemaDTO>(cinema);

        }

        public async Task<CinemsDetailsDTO> GetCinemaDetailsAsync(int id)
        {

            var cinema = await _cinemaRepository.GetByIdAsync(id);
            var movieScreeings = await _movieScreeningService.GetScreeningsByCinemaIdAsync(id);
            var halls = await _hallRepository.GetHAllsByCinemaIdAsync(id);

            var cinemaDTO = _mapper.Map<CinemsDetailsDTO>(cinema);
            cinemaDTO.MovieScreenings = _mapper.Map<List<MovieScreeningDTO>>(movieScreeings);
            cinemaDTO.Halls = _mapper.Map<List<HallDTO>>(halls);

            return cinemaDTO;
        }

        public async Task<CinemaDTO> UpdateAsync(int id, CinemaDTO cinemaDTO)
        {

            var cinema = await _cinemaRepository.GetByIdAsync(id);
            _mapper.Map(cinemaDTO, cinema);
            await _cinemaRepository.UpdateAsync(cinema);
            await _cinemaRepository.SaveAsync();

            return _mapper.Map<CinemaDTO>(cinema);

        }

    }
}
