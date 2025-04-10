﻿using ProjectCinema.Entities;
using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Movie
{
    public class MovieUpdateDTO
    {
        public string? MovieName { get; set; }
        public int? DurationInMinutes { get; set; }
        public int? AgeRestriction { get; set; }
        public DateOnly? ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public string? Language { get; set; }
        public string? ProductionStudio { get; set; }
        public string? Director { get; set; }
        public string? MainCast { get; set; }
        public StatusOfMovie? Status { get; set; } 

    }
}
