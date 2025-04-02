using AutoMapper;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class HallService : GenericService<HallDTO, Hall>, IHallService
    {
        private readonly IHallRepository _hallRepository;
        private readonly IMapper _mapper;
        private readonly ISeatService _seatService;
        private readonly IShowTimeService _showTimeService;
        private readonly ICinemaService _cinemaService;

        public HallService(IHallRepository hallRepository, 
                           IMapper mapper, 
                           ISeatService seatService, 
                           IShowTimeService showTimeService,
                           ICinemaService cinemaService) 
                           : base(hallRepository, mapper)
        {

            _hallRepository = hallRepository;
            _mapper = mapper;
            _seatService = seatService;
            _showTimeService = showTimeService;
            _cinemaService = cinemaService;

        }

        public async Task<HallDTO> CreateHallAsync(HallCreateDTO hallCreateDTO)
        {

            Hall hall = _mapper.Map<Hall>(hallCreateDTO);
            hall.CreatedAt = DateTime.Now;
            hall.HallAvailability = HallAvailability.Open;
            await _hallRepository.AddAsync(hall);
            await _hallRepository.SaveAsync();

            return _mapper.Map<HallDTO>(hall);

        }

        public async Task<HallDetailsDTO> GetHallDetailsAsync(int hallId)
        {

            Hall? hall = await _hallRepository.GetByIdAsync(hallId);

            if(hall == null)
            {
                throw new InvalidOperationException($"Hall with id equals {hallId} does not exists");
            }

            IEnumerable<SeatDTO> seats = await _seatService.GetSeatsByHallIdAsync(hallId);
            IEnumerable<ShowTimeDTO> showTimes = await _showTimeService.GetShowTimesByHallIdAsync(hallId);

            HallDetailsDTO hallDTO = _mapper.Map<HallDetailsDTO>(hall);
            hallDTO.Seats = seats.ToList();
            hallDTO.ShowTimes = showTimes.ToList();

            return hallDTO;

        }

        public async Task<IEnumerable<HallDTO>> GetHallsByAvailiabilityAsync(HallAvailability hallAvailability)
        {

            IEnumerable<Hall> halls = await _hallRepository.GetHallsByAviliabilityAsync(hallAvailability);

            return  _mapper.Map<List<HallDTO>>(halls);

        }

        public async Task<IEnumerable<HallDTO>> GetHallsByCinemaIdAsync(int cinemaId)
        {
            if(await _cinemaService.GetByIdAsync(cinemaId) == null)
            {
                throw new InvalidOperationException($"Cinema with id equals {cinemaId} does not exists")
            }

            IEnumerable<Hall> halls = await _hallRepository.GetHAllsByCinemaIdAsync(cinemaId);

            return _mapper.Map<List<HallDTO>>(halls);

        }

        public async Task<HallDTO> UpdateHallAsync(HallUpdateDTO hallUpdateDTO, int hallId)
        {

            Hall? hall = await _hallRepository.GetByIdAsync(hallId);

            if (hall == null)
            {
                throw new InvalidOperationException($"Hall with id equals {hallId} does not exists");
            }

            _mapper.Map(hallUpdateDTO, hall);
            await _hallRepository.UpdateAsync(hall);
            await _hallRepository.SaveAsync();

            return _mapper.Map<HallDTO>(hall);

        }
    }
}
