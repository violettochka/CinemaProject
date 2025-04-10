using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.Data;

namespace ProjectCinema.Validations.SeatValidation
{
    public class SeatCreateDTOValidator : AbstractValidator<SeatCreateDTO>
    {
        private readonly AplicationDBContext _context;
        private readonly IRowService _rowService;
        public SeatCreateDTOValidator(AplicationDBContext context, IRowService rowService)
        {
            _context = context;
            _rowService = rowService;

            RuleFor(x => x.SeatNumber)
                .NotEmpty().WithMessage("Seat number is a required field")
                .GreaterThan(0).WithMessage("Seat number must be greater than zero.")
                .MustAsync(BeUniqueSeatNumberInRow).WithMessage("Seat number must be unique within the row.");

            RuleFor(x => x.SeatType)
                .NotEmpty().WithMessage("Seat type is required field")
                .IsInEnum().WithMessage("Invalid seat type.");

            RuleFor(x => x.RowId)
                .NotEmpty().WithMessage("Row ID is a required field")
                .MustAsync(async (rowId, cancellation) =>
                await _rowService.GetByIdAsync(rowId) != null);
        }

        private async Task<bool> BeUniqueSeatNumberInRow(SeatCreateDTO dto, int seatNumber, CancellationToken ct)
        {
            return !await _context.Seats
                .AnyAsync(s => s.SeatNumber == seatNumber && s.RowId == dto.RowId, cancellationToken: ct);
        }
    }
}
