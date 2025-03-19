using AutoMapper;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Classes;
using ProjectCinema.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.Services
{
    public class MovieService : GenericService<MovieDTO, Movie>, IMovieService
    {

        private readonly IMovieScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, 
                            IMapper mapper, 
                            IMovieScreeningRepository screeningRepository)
                            :base(movieRepository, mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _screeningRepository = screeningRepository;

        }
        public async Task<MovieDTO> CreateAsync(MovieCreateDTO movieDTO)
        {

            var movie = _mapper.Map<Movie>(movieDTO);
            movie.Status = StatusOfMovie.Active;
            movie.CreatedAt = DateTime.Now;
            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveAsync();

            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByStatusAsync(StatusOfMovie statusOfMovie)
        {

            var movies  = await _movieRepository.GetMoviesByStatusAsync(statusOfMovie);

            return _mapper.Map<IEnumerable<MovieDTO>>(movies);

        }

        public async Task<MovieDetailsDTO> GetMovieDetailsAsync(int id)
        {

            var movie = await _movieRepository.GetByIdAsync(id);
            var movieScreenings = await _screeningRepository.GetMovieSreeningsByMovieIdAsync(movie.MovieId);
            var movieDto = _mapper.Map<MovieDetailsDTO>(movie);
            movieDto.MovieScreenings = _mapper.Map<List<MovieScreeningDTO>>(movieScreenings);

            return movieDto;

        }

        public async Task<MovieDTO> UpdateAsync(int id, MovieUpdateDTO movieDTO)
        {

            var movie = await _movieRepository.GetByIdAsync(id);
            _mapper.Map(movieDTO, movie);
            await _movieRepository.UpdateAsync(movie);
            await _movieRepository.SaveAsync();

            return _mapper.Map<MovieDTO>(movie);

        }
    }
}
