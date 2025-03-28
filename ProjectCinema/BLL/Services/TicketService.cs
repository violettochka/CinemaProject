using AutoMapper;
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
        public TicketService(ITicketRepository ticketRepository,
                             IMapper mapper, 
                             IBookingService bookingService) 
                             : base(ticketRepository, mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public async Task<TicketDTO> CreateTicketAsync(TicketCreateDTO ticketCreateDTO)
        {

            Ticket ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            ticket.TicketStatus = TicketStatus.Active;
            ticket.CreatedAt = DateTime.Now;

            await _ticketRepository.AddAsync(ticket);   
            await _ticketRepository.SaveAsync();

            return _mapper.Map<TicketDTO>(ticket);


        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByBookingIdAsync(int bookingId)
        {
            
            IEnumerable<Ticket> tickets = await _ticketRepository.GetTicketsByBookingIdAsync(bookingId);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);

        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsBySeatIdAsync(int seatId)
        {

            IEnumerable<Ticket> tickets = await  _ticketRepository.GetTicketsBySeatIdAsync(seatId);

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByShowTimeIdAsync(int shoeTimeId)
        {

            IEnumerable<Ticket> tickets = await _ticketRepository.GetTicketsByShowTimeIdAsync(shoeTimeId);

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
