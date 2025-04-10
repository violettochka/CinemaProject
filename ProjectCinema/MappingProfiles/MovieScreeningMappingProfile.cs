using AutoMapper;
using ProjectCinema.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.MovieScreening;

namespace ProjectCinema.MappingProfiles
{
    public class MovieScreeningMappingProfile: Profile
    {
        public MovieScreeningMappingProfile()
        {
            // Create automapper for general moviescreening info
            CreateMap<MovieScreening, MovieScreeningDTO>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Cinema, opt => opt.MapFrom(src => src.Cinema));

            // Create automapper for details moviescreening info
            CreateMap<MovieScreening, MovieScreeningDetailsDTO>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Cinema, opt => opt.MapFrom(src => src.Cinema))
                .ForMember(dest => dest.ShowTimes, opt => opt.MapFrom(src => src.ShowTimes));

            // Create automapper for creation the moviescreening
            CreateMap<MovieScreeningCreateDTO, MovieScreening>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId));

            // Create automapper for updating the moviescreening
            CreateMap<MovieScreeningUpdateDTO, MovieScreening>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

        }
    }
}
