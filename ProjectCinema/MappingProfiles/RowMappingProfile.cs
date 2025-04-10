using AutoMapper;
using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class RowMappingProfile : Profile
    {
        public RowMappingProfile() 
        {
            CreateMap<Row, RowDTO>();

            CreateMap<Row, RowDetailsDTO>()
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Row, RowCreateDTO>()
                .ForMember(dest => dest.HallId, opt => opt.MapFrom(src => src.HallId));

            CreateMap<Row, RowUpdateDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }



    }
}
