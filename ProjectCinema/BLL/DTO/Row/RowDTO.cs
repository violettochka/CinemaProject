using ProjectCinema.Entities;

namespace ProjectCinema.BLL.DTO.Row
{
    public class RowDTO
    {
        public int Id { get; set; }
        public Hall? Hall { get; set; }
        public int RowNumber { get; set; }
    }
}
