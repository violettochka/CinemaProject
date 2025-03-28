using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.Entities;
using ProjectCinema.Enums;

namespace ProjectCinema.BLL.Interfaces
{
    public interface ISeatService : IGenericService<SeatDTO, Seat>
    {
        Task<SeatDetailsDTO> GetSeatDetailsAsync(int seatId);
        Task<SeatDTO> CreateSeatAsync(SeatCreateDTO seatCreateDTO);
        Task<SeatDTO> UpdateSeatAsync(SeatUpdateDTO seatUpdateDTO, int seatId);
        Task<IEnumerable<SeatDTO>> GetSeatsByHallIdAsync (int hallId);
        Task<IEnumerable<SeatDTO>> GetSeatsByShowTimeId(int showTimeId, SeatAvailability? seatAvailability = null);

    }
}
