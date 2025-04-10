using AutoMapper;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class HallMappingProfile : Profile
    {
        public HallMappingProfile()
        {
            //Create automapper for general hall info
            CreateMap<Hall, HallDTO>();

            //Create automapper for details hall info
            CreateMap<Hall, HallDetailsDTO>()
                .ForMember(dest => dest.Cinema, opt => opt.MapFrom(src => src.Cinema))
                .ForMember(dest => dest.ShowTimes, opt => opt.MapFrom(src => src.ShowTimes))
                .ForMember(dest => dest.Rows, opt => opt.MapFrom(src => src.Rows));

            // Create automapper for creation the hall
            CreateMap<HallCreateDTO, Hall>()
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId));

            // Create automapper for updating the hall
            CreateMap<HallUpdateDTO, Hall>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

        }
    }
}
