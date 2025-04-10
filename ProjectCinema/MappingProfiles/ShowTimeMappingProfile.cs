using AutoMapper;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Ticket;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class ShowTimeMappingProfile : Profile
    {
        public ShowTimeMappingProfile()
        {
            //Create automapper for general showtime info
            CreateMap<ShowTime, ShowTimeDTO>();

            //Create automapper for details shotime info
            CreateMap<ShowTime, ShowTimeDetailsDTO>()
                .ForMember(dest => dest.MovieScreening, opt => opt.MapFrom(src => src.MovieScreening))
                .ForMember(dest => dest.Hall, opt => opt.MapFrom(src => src.Hall))
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets));

            //Create automapper for creation the showtime
            CreateMap<ShowTimeCreateDTO, ShowTime>()
                .ForMember(dest => dest.HallId, opt => opt.MapFrom(src => src.HallId))
                .ForMember(dest => dest.MovieScreeningId, opt => opt.MapFrom(src => src.MovieScreeningId));

            //Create automapper for updating the showtime
            CreateMap<ShowTimeUpdateDTO, ShowTime>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
