using AutoMapper;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            //Create automapper for general cinema info
            CreateMap<Cinema, CinemaDTO>();

            //Create automapper for details cinema info
            CreateMap<Cinema, CinemaDetailsDTO>()
                .ForMember(dest => dest.Halls, opt => opt.MapFrom(src => src.Halls))
                .ForMember(dest => dest.MovieScreenings, opt => opt.MapFrom(src => src.MovieScreenings));

            //Create automapper for creation the cinema
            CreateMap<CinemaCreateDTO, Cinema>();

            //Create automapper for updating the cinema
            CreateMap<CinemaUpdateDTO, Cinema>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 

        }
    }
}
