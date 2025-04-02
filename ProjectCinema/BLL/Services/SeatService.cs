using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class SeatService : GenericService<SeatDTO, Seat>, ISeatService
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly ITicketService _ticketService;
        private readonly IHallService _hallService;
        private readonly IShowTimeService _showTimeService;

        public SeatService(ISeatRepository seatRepository, 
                           IMapper mapper, 
                           ITicketService ticketService, 
                           IHallService hallService,
                           IShowTimeService showTimeService) 
                           : base(seatRepository, mapper)
        {

            _mapper = mapper;
            _seatRepository = seatRepository;
            _ticketService = ticketService;
            _hallService = hallService;
            _showTimeService = showTimeService;

        }

        public async Task<SeatDTO> CreateSeatAsync(SeatCreateDTO seatCreateDTO)
        {

            if( await _hallService.GetByIdAsync(seatCreateDTO.HallId) == null)
            {
                throw new Exception($"Hall with id equal {seatCreateDTO.HallId} does not exists");
            }

            var existingSeat = (await _seatRepository.GetAllAsync())
                                                     .FirstOrDefault(s => s.HallId == seatCreateDTO.HallId
                                                      && s.RowNumber == seatCreateDTO.RowNumber
                                                      && s.SeatNumber == seatCreateDTO.SeatNumber);


            if (existingSeat != null)
            {
                throw new InvalidOperationException($"Seat number {seatCreateDTO.SeatNumber} in row {seatCreateDTO.RowNumber} already exists in this hall.");
            }

            // 4. Проверка корректности типа сиденья
            if (!Enum.IsDefined(typeof(SeatType), seatCreateDTO.SeatType))
            {
                throw new ArgumentException("Incorrect seat type.");
            }

            var seat = _mapper.Map<Seat>(seatCreateDTO);
            seat.CreatedAt = DateTime.Now;
            seat.SeatAvailability = SeatAvailability.Available;
            await _seatRepository.AddAsync(seat);
            await _seatRepository.SaveAsync();

            return _mapper.Map<SeatDTO>(seat);

        }

        public async Task<SeatDetailsDTO> GetSeatDetailsAsync(int seatId)
        {

            if( await _seatRepository.GetByIdAsync(seatId) == null )
            {
                throw new InvalidOperationException($"Seat with id equal {seatId} does not exists");
            }
            
            Seat seat = await _seatRepository.GetByIdAsync(seatId);
            SeatDetailsDTO seatDTO = _mapper.Map<SeatDetailsDTO>(seat);
            IEnumerable<TicketDTO> ticket = await _ticketService.GetTicketsBySeatIdAsync(seatId);
            _mapper.Map<List<TicketDTO>>(ticket);

            return seatDTO;

        }

        public async Task<IEnumerable<SeatDTO>> GetSeatsByHallIdAsync(int hallId)
        {
            if(await _hallService.GetByIdAsync(hallId) == null)
            {
                throw new InvalidOperationException($"Hall with id equal {hallId} does not exists");
            }

            IEnumerable<Seat>? seats = await _seatRepository.GetSeatsByHallIdAsync(hallId);

            return _mapper.Map<IEnumerable<SeatDTO>>(seats);

        }

        public async Task<IEnumerable<SeatDTO>> GetSeatsByShowTimeId(int showTimeId, SeatAvailability? seatAvailability = null)
        {

            ShowTimeDetailsDTO showTime = await _showTimeService.GetShowTimeDetailsAsync(showTimeId);


            if (showTime == null)
            {
                throw new Exception($"ShowTime with id equal {showTimeId} does not exist");
            }

            List<SeatDTO> seats = (await GetSeatsByHallIdAsync(showTime.HallId)).ToList();

            if (seatAvailability.HasValue)
            {
                seats = seats.Where(s => s.SeatAvailability == seatAvailability.Value).ToList();
            }

            return seats;

        }

        public async Task<SeatDTO> UpdateSeatAsync(SeatUpdateDTO seatUpdateDTO, int seatId)
        {

            Seat seat = await _seatRepository.GetByIdAsync(seatId);
            _mapper.Map(seatUpdateDTO, seat);

            await _seatRepository.UpdateAsync(seat);
            await _seatRepository.SaveAsync();

            return _mapper.Map<SeatDTO>(seat);

        }
    }
}
