using AutoMapper;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            // Create automapper for general movie info
            CreateMap<Movie, MovieDTO>();

            //Create automapper for details movie info
            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.MovieScreenings, opt => opt.MapFrom(src =>src.MovieScreenings));

            //Create automapper for creation the movie
            CreateMap<MovieCreateDTO, Movie>();

            //Create automapper for updating the movie
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
