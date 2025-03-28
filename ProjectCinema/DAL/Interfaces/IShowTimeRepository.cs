﻿using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.Repositories.Interfaces
{
    public interface IShowTimeRepository: IGenericRepository<ShowTime>
    {
        Task<IEnumerable<ShowTime>> GetShowTimesAsync(ShowTimeStatus? showTimeStatus = null);
        Task<IEnumerable<ShowTime>> GetShowTimesByMovieScreeningIdAsync(int id);
        Task<IEnumerable<ShowTime>> GetShowTimesByHallIdAsync(int id);
    }
}
