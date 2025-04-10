using AutoMapper;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.DAL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Classes;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class TicketService : GenericService<TicketDTO, Ticket>, ITicketService
    {
        private ITicketRepository _ticketRepository;
        private IMapper _mapper;
        private IBookingService _bookingService;
        private IShowTimeService _showTimeService;
        private ISeatService _seatService;
        public TicketService(ITicketRepository ticketRepository,
                             IMapper mapper, 
                             IBookingService bookingService,
                             IShowTimeService showTimeService,
                             ISeatService seatService) 
                             : base(ticketRepository, mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _bookingService = bookingService;
            _showTimeService = showTimeService;
            _seatService = seatService;
        }

        public async Task<TicketDTO> CreateTicketAsync(TicketCreateDTO ticketCreateDTO)
        {
            // 1. Проверка существования сеанса
            ShowTimeDTO showTimeDTO = await _showTimeService.GetByIdAsync(ticketCreateDTO.ShowTimeId);
            if (showTimeDTO == null)
            {
                throw new ArgumentException($"ShowTime with id equal {ticketCreateDTO.ShowTimeId} does not exist");
            }

            SeatDTO seatDTO = await _seatService.GetByIdAsync(ticketCreateDTO.SeatId);

            if (seatDTO == null)
            {
                throw new ArgumentException($"Seat with id equal {ticketCreateDTO.SeatId} does not not exist");
            }

            // 3. Проверка, не занят ли уже этот билет на данный сеанс
            var existingTicket = await _ticketRepository.FirstOrDefaultAsync(t =>
                t.ShowTimeId == ticketCreateDTO.ShowTimeId &&
                t.SeatId == ticketCreateDTO.SeatId);

            if (existingTicket != null)
            {
                throw new InvalidOperationException("A ticket for this session has already been purchased for this seat.");
            }

            // 5. Проверка статуса места (например, нельзя продавать на сломанное или VIP без спец-доступа)
            if (seatDTO.SeatAvailability != SeatAvailability.Available)
            {
                throw new InvalidOperationException("This place is not available for booking.");
            }

            // 6. Проверка даты сеанса (нельзя продавать билет на прошедший сеанс)
            if (showTimeDTO.StartTime < DateTime.Now)
            {
                throw new InvalidOperationException("It is not possible to sell a ticket for the previous session.");
            }


            Ticket ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            ticket.TicketStatus = TicketStatus.Active;
            ticket.CreatedAt = DateTime.Now;

            await _ticketRepository.AddAsync(ticket);   
            await _ticketRepository.SaveAsync();

            return _mapper.Map<TicketDTO>(ticket);


        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByBookingIdAsync(int bookingId)
        {
            if(await _bookingService.GetByIdAsync(bookingId) == null)
            {
                throw new InvalidOperationException($"Booking with id equal {bookingId} does not exist");
            }

            IEnumerable<Ticket> tickets = await _ticketRepository.GetTicketsByBookingIdAsync(bookingId);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);

        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsBySeatIdAsync(int seatId)
        {
            if(await _seatService.GetByIdAsync(seatId) == null)
            {
                throw new InvalidOperationException($"Seat with id equal {seatId} does not exist");
            }

            IEnumerable<Ticket> tickets = await  _ticketRepository.GetTicketsBySeatIdAsync(seatId);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);

        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByShowTimeIdAsync(int showTimeId)
        {
            if(await _showTimeService.GetByIdAsync(showTimeId) == null)
            {
                throw new InvalidOperationException($"ShowTime with id equal {showTimeId} does not exist");
            }

            IEnumerable<Ticket> tickets = await _ticketRepository.GetTicketsByShowTimeIdAsync(showTimeId);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);

        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByTicketStatusAsync(TicketStatus ticketStatus)
        {
            
            IEnumerable<Ticket> tickets = await _ticketRepository.GetTicketsByTicketStatusAsync(ticketStatus);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);

        }

        public async Task<TicketDTO> UpdateTicketAsync(TicketUpdateDTO ticketUpdateDTO, int ticketId)
        {

            Ticket ticket = await _ticketRepository.GetByIdAsync(ticketId);
            _mapper.Map(ticketUpdateDTO, ticket);

            await _ticketRepository.UpdateAsync(ticket);
            await _ticketRepository.SaveAsync();

            return _mapper.Map<TicketDTO>(ticket);

        }
    }
}
