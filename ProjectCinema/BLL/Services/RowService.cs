using AutoMapper;
using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.DAL.Interfaces;
using ProjectCinema.Entities;
using ProjectCinema.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace ProjectCinema.BLL.Services
{
    public class RowService : GenericService<RowDTO, Row>, IRowService
    {
        private readonly IMapper _mapper;
        private readonly IRowRepository _rowRepository;
        private readonly ISeatService _seatService; 
        public RowService(IRowRepository rowRepository, 
                          IMapper mapper,
                          ISeatService seatService) : base(rowRepository, mapper)
        {
            _rowRepository = rowRepository;
            _mapper = mapper;
            _seatService = seatService;
        }

        public async Task<RowDTO> CreateRowAsync(RowCreateDTO rowCreateDTO)
        {
            Row row = _mapper.Map<Row>(rowCreateDTO);
            await _rowRepository.AddAsync(row);
            await _rowRepository.SaveAsync();

            return _mapper.Map<RowDTO>(row);

        }

        public async Task<RowDetailsDTO> GetRowDetailsByIdAsync(int rowId)
        {
          
            Row row =  await _rowRepository.GetByIdAsync(rowId);
            if(row == null)
            {
                throw new KeyNotFoundException($"Row with id equal {rowId} does not exist");
            }

            RowDetailsDTO rowDetailsDTO = _mapper.Map<RowDetailsDTO>(row);

            IEnumerable<SeatDTO> seatDTOs = await _seatService.GetSeatsByRowIdAsync(rowId);
            rowDetailsDTO.Seats = seatDTOs.ToList();
            
            return rowDetailsDTO;

        }

        public async Task<IEnumerable<RowDTO>> GetRowsByHallIdAsync(int hallId)
        {
            IEnumerable<Row> rows = await _rowRepository.GetRowsByHallIdAsync(hallId);

            return _mapper.Map<IEnumerable<RowDTO>>(rows);    
        }

        public async Task<RowDTO> UpdateRowAsync(RowUpdateDTO rowUpdateDTO, int rowId)
        {

            Row? row = await _rowRepository.GetByIdAsync(rowId);
            if (row == null)
            {
                throw new KeyNotFoundException($"Row with id equal {rowId} does not exists");
            }

            _mapper.Map(rowUpdateDTO, row);

            await _rowRepository.UpdateAsync(row);
            await _rowRepository.SaveAsync();

            return _mapper.Map<RowDTO>(row);

        }
    }
}
