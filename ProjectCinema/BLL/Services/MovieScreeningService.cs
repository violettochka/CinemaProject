using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Enums;
using ProjectCinema.Repositories.Classes;
using ProjectCinema.Repositories.Interfaces;

namespace ProjectCinema.BLL.Services
{
    public class MovieScreeningService : GenericService<MovieScreeningDTO, MovieScreening>, IMovieScreeningService
    {
        private readonly IMovieScreeningRepository _movieScreeningRepository;
        private readonly IMapper _mapper;
        private readonly ICinemaService _cinemaService;
        private readonly IMovieService _movieService;

        public MovieScreeningService(
                              IMovieScreeningRepository movieScreeningRepository, 
                              IMapper mapper,
                              ICinemaService cinemaService,
                              IMovieService movieService)
                              : base(movieScreeningRepository, mapper)
        {

            _mapper = mapper;
            _movieScreeningRepository = movieScreeningRepository;
            _cinemaService = cinemaService;
            _movieService = movieService;
        }
        public async Task<MovieScreeningDTO> CreateAsync(MovieScreeningCreateDTO screeningDTO)
        {


            // Проверка на существование фильма и кинотеатра
            CinemaDTO cinema = await _cinemaService.GetByIdAsync(screeningDTO.CinemaId);
            if (cinema == null)
            {
                throw new ArgumentException("Cinema with this ID not found.");
            }

            MovieDTO movie = await _movieService.GetByIdAsync(screeningDTO.MovieId);
            if (movie == null)
            {
                throw new ArgumentException("Movie with this ID not found.");
            }

            // Проверка уникальности сочетания MovieId и CinemaId
            bool IsScreeningExists = await IsMovieScreeningExistsByCinemaAndMovieAsync(screeningDTO.CinemaId, screeningDTO.MovieId);
            if (IsScreeningExists)
            {
                throw new InvalidOperationException("A screening of this film already exists in this cinema.");
            }

            // Проверка на валидность времени начала
            if (screeningDTO.StartDate < DateTime.UtcNow)
            {
                throw new ArgumentException("The screening start time cannot be in the past.");
            }

            // Проверка на перекрытие времени (другие скрининги в этом кинотеатре)
            var overlappingScreenings = GetOverlappingScreeningsAsync(screeningDTO.CinemaId, screeningDTO.StartDate, screeningDTO.EndDate);

            if (overlappingScreenings != null)
            {
                throw new InvalidOperationException("Время скрининга перекрывается с другим представлением в этом кинотеатре.");
            }

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
            if( await _cinemaService.GetByIdAsync(cinemaId) == null)
            {
                throw new InvalidOperationException($"Cinema with id equal {cinemaId} does not exists");
            }

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieScreeningsByCimenaIdAsync(cinemaId);

            return _mapper.Map<List<MovieScreeningDTO>>(movieScreenings);

        }

        public async Task<IEnumerable<MovieScreeningDTO>> GetMovieSreeningsByMovieIdAsync(int movieId)
        {
            if( await _movieService.GetByIdAsync(movieId) == null)
            {
                throw new InvalidOperationException($"Movie with id equal {movieId} does not exists");
            }

            IEnumerable<MovieScreening>? movieScreenings = await _movieScreeningRepository.GetMovieSreeningsByMovieIdAsync(movieId);

            return _mapper.Map<IEnumerable<MovieScreeningDTO>>(movieScreenings);

        }

        public async Task<IEnumerable<MovieScreeningDetailsDTO>> GetScreeningsDetailsByMovieIdAsync(int movieId)
        {

            if (await _movieService.GetByIdAsync(movieId) == null)
            {
                throw new InvalidOperationException($"Movie with id equal {movieId} does not exists");
            }

            IEnumerable<MovieScreening> movieScreenings = await _movieScreeningRepository.GetMovieSreeningsByMovieIdAsync(movieId);

            return _mapper.Map<IEnumerable<MovieScreeningDetailsDTO>>(movieScreenings);

        }

        public async Task<MovieScreeningDTO> UpdateAsync(int id, MovieScreeningUpdateDTO screeningDTO)
        {
            if( await _movieScreeningRepository.GetByIdAsync(id) == null)
            {
                throw new InvalidOperationException($"Movie screening id equal {id} does not exits");
            }

            MovieScreening movieScreening = await  _movieScreeningRepository.GetByIdAsync(id);
            _mapper.Map(screeningDTO, movieScreening);
            await _movieScreeningRepository.UpdateAsync(movieScreening);
            await _movieScreeningRepository.SaveAsync();

            return _mapper.Map<MovieScreeningDTO>(movieScreening);

        }

        public async Task<bool> IsMovieScreeningExistsByCinemaAndMovieAsync(int cinemaId, int movieId)
        {
            if( await _cinemaService.GetByIdAsync(cinemaId) == null)
            {
                throw new InvalidOperationException($"Cinema id equal {cinemaId} does not exists");
            }

            if( await _movieService.GetByIdAsync(movieId) == null)
            {
                throw new InvalidOperationException($"Movie id equal {movieId} does not exists");
            }

            return await _movieScreeningRepository.IsMovieScreeningExistsByCinemaAndMovieAsync(cinemaId, movieId);
        }

        public async Task<IEnumerable<MovieScreeningDTO>> GetOverlappingScreeningsAsync(int cinemaId, DateTime startTime, DateTime endTime)
        {
            if( await _cinemaService.GetByIdAsync(cinemaId) == null)
            {
                throw new InvalidOperationException($"Cinema id equal {cinemaId} does not exists");
            }

            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be earlier than end time.");
            }

            IEnumerable<MovieScreening> movieScreening = await _movieScreeningRepository.GetOverlappingScreeningsAsync(cinemaId, startTime, endTime);

            return _mapper.Map<IEnumerable<MovieScreeningDTO>>(movieScreening);
        }

    }
}
