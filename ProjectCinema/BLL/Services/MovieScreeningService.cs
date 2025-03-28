using AutoMapper;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class MovieScreeningService : GenericService<MovieScreeningDTO, MovieScreening>, IMovieScreeningService
    {
        private readonly IMovieScreeningRepository _movieScreeningRepository;
        private readonly IMapper _mapper;

        public MovieScreeningService(IMovieScreeningRepository movieScreeningRepository, 
                              IMapper mapper)
                              :base(movieScreeningRepository, mapper)
        {

            _mapper = mapper;
            _movieScreeningRepository = movieScreeningRepository;

        }
        public async Task<MovieScreeningDTO> CreateAsync(MovieScreeningCreateDTO screeningDTO)
        {
            MovieScreening movieScreening = _mapper.Map<MovieScreening>(screeningDTO);
            movieScreening.CreatedAt = DateTime.Now;
            movieScreening.MovieScreeningRelevance = MovieScreeningRelevance.Relevant;

            await _movieScreeningRepository.AddAsync(movieScreening);
            await _movieScreeningRepository.SaveAsync();

            return _mapper.Map<MovieScreeningDTO>(movieScreening);
        }

        public async Task<IEnumerable<MovieScreeningDTO>> GetMovieScreeningsByRelevanceAsync(MovieScreeningRelevance relevance)
        {

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieScreeningsByRelevanceAsync(relevance);

            return _mapper.Map<List<MovieScreeningDTO>>(movieScreenings);

        }


        public async Task<IEnumerable<MovieScreeningDTO>> GetScreeningsByCinemaIdAsync(int cinemaId)
        {

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieScreeningsByCimenaIdAsync(cinemaId);

            return _mapper.Map<List<MovieScreeningDTO>>(movieScreenings);

        }

        public async Task<IEnumerable<MovieScreeningDTO>> GetMovieSreeningsByMovieIdAsync(int movieId)
        {

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieSreeningsByMovieIdAsync(movieId);

            return _mapper.Map<IEnumerable<MovieScreeningDTO>>(movieScreenings);

        }

        public async Task<IEnumerable<MovieScreeningDetailsDTO>> GetScreeningsDetailsByMovieIdAsync(int movieId)
        {

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieSreeningsByMovieIdAsync(movieId);

            return _mapper.Map<IEnumerable<MovieScreeningDetailsDTO>>(movieScreenings);

        }

        public async Task<MovieScreeningDTO> UpdateAsync(int id, MovieScreeningUpdateDTO screeningDTO)
        {

            MovieScreening movieScreening = await  _movieScreeningRepository.GetByIdAsync(id);
            _mapper.Map(screeningDTO, movieScreening);
            await _movieScreeningRepository.UpdateAsync(movieScreening);
            await _movieScreeningRepository.SaveAsync();

            return _mapper.Map<MovieScreeningDTO>(movieScreening);

        }
    }
}
