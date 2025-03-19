using AutoMapper;
using ProjectCinema.BLL.DTO.Booking;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            //Create automapper for general ticket info
            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowTime))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat))
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src.Booking));

            //Create automapper for details ticket info
            CreateMap<Ticket, TicketDetailsDTO>()
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowTime))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat))
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src.Booking));

            //Create automapper for creation ticket
            CreateMap<TicketCreateDTO, Ticket>()
                .ForMember(dest => dest.ShowTimeId, opt => opt.MapFrom(src => src.ShowTimeId))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId));

            //Create automapper for updating ticket
            CreateMap<TicketUpdateDTO, Ticket>();
        }
    }
}
