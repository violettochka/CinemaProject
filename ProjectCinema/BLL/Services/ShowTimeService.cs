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

        public ShowTimeService(IShowTimeRepository showTimeRepository, 
                               IMapper mapper,
                               IMovieScreeningService movieScreeningService,
                               ITicketService ticketService) 
                               : base(showTimeRepository, mapper)
        {

            _showTimeRepository = showTimeRepository;
            _mapper = mapper;
            _movieScreeningService = movieScreeningService;
            _ticketService = ticketService;

        }

        public async Task<ShowTimeDTO> CreateShowTimeAsync(ShowTimeCreateDTO showTimeCreateDTO)
        {

            ShowTime showTime = _mapper.Map<ShowTime>(showTimeCreateDTO);
            showTime.CreatedAt = DateTime.Now;
            showTime.ShowTimeStatus = ShowTimeStatus.Active;
            await _showTimeRepository.AddAsync(showTime);
            await _showTimeRepository.SaveAsync();

            return _mapper.Map<ShowTimeDTO>(showTime);
            
        }

        public async Task<IEnumerable<ShowTimeDTO>> GetAvailiableShowTimesByMovieId(int movieId)
        {

            IEnumerable<MovieScreeningDetailsDTO> movieScreenings = await _movieScreeningService.GetScreeningsDetailsByMovieIdAsync(movieId);

            if( movieScreenings == null )
            {
                throw new Exception($"Has not found moviescreenungs by movie id that equal {movieId}");
            }

            List<ShowTimeDTO> showTimes = movieScreenings
                            .SelectMany(ms => ms.ShowTimes)
                            .Where(st => st.ShowTimeStatus == ShowTimeStatus.Active)
                            .ToList();

            return _mapper.Map<List<ShowTimeDTO>>(showTimes);

        }

        public async Task<ShowTimeDetailsDTO> GetShowTimeDetailsAsync(int showTimeId)
        {

            ShowTime showTime = await _showTimeRepository.GetByIdAsync(showTimeId);
            IEnumerable<TicketDTO> tickets = await _ticketService.GetTicketsByShowTimeIdAsync(showTimeId);
            ShowTimeDetailsDTO showTimeDTO = _mapper.Map<ShowTimeDetailsDTO>(showTime);
            showTimeDTO.Tickets = _mapper.Map<List<TicketDTO>>(tickets);

            return showTimeDTO;

        }

        public async Task<IEnumerable<ShowTimeDTO>> GetShowTimesByHallIdAsync(int hallId)
        {

            IEnumerable<ShowTime> showTimes = await _showTimeRepository.GetShowTimesByHallIdAsync(hallId);

            return _mapper.Map<List<ShowTimeDTO>>(showTimes);
        }

        public async Task<IEnumerable<ShowTimeDTO>> GetShowTimesByMovieScreeningIdAsync(int movieScreeningId)
        {

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

            ShowTime showTime = await _showTimeRepository.GetByIdAsync(showTimeId);
            _mapper.Map(showTimeUpdateDTO, showTime);

            await _showTimeRepository.UpdateAsync(showTime);
            await _showTimeRepository.SaveAsync();

            return _mapper.Map<ShowTimeDTO>(showTime);

        }
    }
}
