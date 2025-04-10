﻿using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.ShowTime;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.DTO.Row;

namespace ProjectCinema.BLL.DTO.Halls
{
    public class HallDetailsDTO
    {
        public int HallId { get; set; }
        public string? HallName { get; set; }
        public Capacity Capacity { get; set; }
        public HallAvailability HallAvailability { get; set; }
        public int RowCount { get; set; }
        public CinemaDTO? Cinema { get; set; }

        public ICollection<ShowTimeDTO>? ShowTimes { get; set; }
        public ICollection<RowDTO>? Rows { get; set; }
    }
}
