using AutoMapper;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Classes;
using ProjectCinema.Repositories.Interfaces;
using System.Data;

namespace ProjectCinema.BLL.Services
{
    public class ShowTimeService : GenericService<ShowTimeDTO, ShowTime>, IShowTimeService
    {
        private readonly IMapper _mapper;
        private readonly IShowTimeRepository _showTimeRepository;
        private readonly IMovieScreeningService _movieScreeningService;
        private readonly ITicketService _ticketService;
        private readonly IHallService _hallService;
        private readonly IMovieService _movieService;

        public ShowTimeService(IShowTimeRepository showTimeRepository, 
                               IMapper mapper,
                               IMovieScreeningService movieScreeningService,
                               ITicketService ticketService,
                               IHallService hallService,
                               IMovieService movieService) 
                               : base(showTimeRepository, mapper)
        {

            _showTimeRepository = showTimeRepository;
            _mapper = mapper;
            _movieScreeningService = movieScreeningService;
            _ticketService = ticketService;
            _hallService = hallService;
            _movieService = movieService;

        }

        public async Task<ShowTimeDTO> CreateShowTimeAsync(ShowTimeCreateDTO showTimeCreateDTO)
        {



            // Проверка корректности времени
            if (showTimeCreateDTO.StartTime <= DateTime.Now)
            {
                throw new ArgumentException("The session start time must be in the future.");
            }

            if (showTimeCreateDTO.EndTime <= showTimeCreateDTO.StartTime)
            {
                throw new ArgumentException("The end time of the session must be later than the start time.");
            }

            if (await _hallService.GetByIdAsync(showTimeCreateDTO.HallId) == null)
            {
                throw new ArgumentException($"Hall id equal {showTimeCreateDTO.HallId} does not exist");
            }

            if (await _movieScreeningService.GetByIdAsync(showTimeCreateDTO.MovieScreeningId) == null)
            {
                throw new ArgumentException($"MovieScreening is equal {showTimeCreateDTO.MovieScreeningId} does not exist");
            }

            ShowTime showTime = _mapper.Map<ShowTime>(showTimeCreateDTO);
            showTime.CreatedAt = DateTime.Now;
            showTime.ShowTimeStatus = ShowTimeStatus.Active;

            await _showTimeRepository.AddAsync(showTime);
            await _showTimeRepository.SaveAsync();

            return _mapper.Map<ShowTimeDTO>(showTime);
            
        }

        public async Task<IEnumerable<ShowTimeDTO>> GetAvailiableShowTimesByMovieId(int movieId)
        {

            if(await _movieService.GetByIdAsync(movieId) == null)
            {
                throw new ArgumentException($"Movie id equal {movieId} does not exist");
            }

            IEnumerable<MovieScreeningDetailsDTO> movieScreenings = await _movieScreeningService.GetScreeningsDetailsByMovieIdAsync(movieId);

            if( movieScreenings == null )
            {
                throw new Exception($"Has not found moviescreenings by movie id that equal {movieId}");
            }

            List<ShowTimeDTO>? showTimes = movieScreenings
                            .SelectMany(ms => ms.ShowTimes)
                            .Where(st => st.ShowTimeStatus == ShowTimeStatus.Active)
                            .ToList();

            return _mapper.Map<List<ShowTimeDTO>>(showTimes);

        }

        public async Task<ShowTimeDetailsDTO> GetShowTimeDetailsAsync(int showTimeId)
        {

            if(await _showTimeRepository.GetByIdAsync(showTimeId) == null)
            {
                throw new Exception($"ShowTime id equal {showTimeId} does not exist");
            }

            ShowTime showTime = await _showTimeRepository.GetByIdAsync(showTimeId);
            IEnumerable<TicketDTO> tickets = await _ticketService.GetTicketsByShowTimeIdAsync(showTimeId);
            ShowTimeDetailsDTO showTimeDTO = _mapper.Map<ShowTimeDetailsDTO>(showTime);
            showTimeDTO.Tickets = _mapper.Map<List<TicketDTO>>(tickets);

            return showTimeDTO;

        }

        public async Task<IEnumerable<ShowTimeDTO>> GetShowTimesByHallIdAsync(int hallId)
        {

            if(await _hallService.GetByIdAsync(hallId) == null)
            {
                throw new Exception($"Hall id equal {hallId} does not exist");
            }

            IEnumerable<ShowTime>? showTimes = await _showTimeRepository.GetShowTimesByHallIdAsync(hallId);

            return _mapper.Map<List<ShowTimeDTO>>(showTimes);
        }

        public async Task<IEnumerable<ShowTimeDTO>> GetShowTimesByMovieScreeningIdAsync(int movieScreeningId)
        {

            if(await _movieScreeningService.GetByIdAsync(movieScreeningId) == null)
            {
                throw new Exception($"MovieScreening id equal {movieScreeningId} does not exist");
            }

            IEnumerable<ShowTime> showTimes = await _showTimeRepository.GetShowTimesByMovieScreeningIdAsync(movieScreeningId);

            return _mapper.Map<IEnumerable<ShowTimeDTO>>(showTimes);

        }

        public async Task<IEnumerable<ShowTimeDTO>> GetShowTimesByStatus(ShowTimeStatus showTimeStatus)
        {

           IEnumerable<ShowTime> showTimes = await _showTimeRepository.GetShowTimesAsync(showTimeStatus);

            return _mapper.Map<IEnumerable<ShowTimeDTO>>(showTimes);

        }

        public async Task<ShowTimeDTO> UpdateShowTimeAsync(ShowTimeUpdateDTO showTimeUpdateDTO, int showTimeId)
        {

            if (await _showTimeRepository.GetByIdAsync(showTimeId) == null)
            {
                throw new Exception($"ShowTime id equal {showTimeId} does not exist");
            }

            ShowTime showTime = await _showTimeRepository.GetByIdAsync(showTimeId);
            _mapper.Map(showTimeUpdateDTO, showTime);

            await _showTimeRepository.UpdateAsync(showTime);
            await _showTimeRepository.SaveAsync();

            return _mapper.Map<ShowTimeDTO>(showTime);

        }
    }
}
