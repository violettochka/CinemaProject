using AutoMapper;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class SeatMappingProfile : Profile
    {
        public SeatMappingProfile()
        {
            //Create automapper for general seat info
            CreateMap<Seat, SeatDTO>();

            //Create automapper for details seat info
            CreateMap<Seat, SeatDetailsDTO>()
                .ForMember(dest => dest.Hall, opt => opt.MapFrom(src => src.Hall))
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets));

            //Create automapper for creation the seat
            CreateMap<SeatCreateDTO, Seat>()
                .ForMember(dest => dest.HallId, opt => opt.MapFrom(src => src.HallId));

            //Create automapper for updating the seat
            CreateMap<SeatUpdateDTO, Seat>();

        }
    }
}
