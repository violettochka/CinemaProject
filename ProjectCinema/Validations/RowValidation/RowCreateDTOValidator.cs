using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.BLL.Services;
using ProjectCinema.Data;
using ProjectCinema.Entities;
using System;

namespace ProjectCinema.Validations.RowValidation
{
    public class RowCreateDTOValidator : AbstractValidator<RowCreateDTO>
    {
        private readonly IHallService _hallService;
        private readonly AplicationDBContext _context;
        public RowCreateDTOValidator(IHallService hallService, AplicationDBContext aplicationDBContext)
        {
            _hallService = hallService;
            _context = aplicationDBContext;

            RuleFor(r => r.HallId)
                .NotEmpty().WithMessage("Each row must be connected to an existing hall")
                .MustAsync(async (hallId, cancellation) =>
                await _hallService.GetByIdAsync(hallId) != null)
                .WithMessage("Hall does not exist");

            RuleFor(r => r.RowNumber)
                .NotEmpty().WithMessage("Row number is required")
                .GreaterThan(0).WithMessage("Row number must be a positive number")

            .MustAsync(async (dto, rowNumber, cancellation) =>
            {
                var hall = await _hallService.GetByIdAsync(dto.HallId);
                return rowNumber <= hall.RowCount;
            }).WithMessage("Row number exceeds the total number of rows allowed in the hall")

            .MustAsync(async (dto, rowNumber, cancellation) =>
            {
                return !await _context.Rows
                    .AnyAsync(r => r.HallId == dto.HallId && r.RowNumber == rowNumber, cancellation);
            }).WithMessage("Row number must be unique within the hall");

        }

       
    }
}
