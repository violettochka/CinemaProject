using AutoMapper;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class PromocodeMappingProfile : Profile
    {
        public PromocodeMappingProfile()
        {
            //Create automapper for general promocode info
            CreateMap<Promocode, PromocodeDTO>();

            //Create automepper for details promocode info
            CreateMap<Promocode, PromocodeDetailsDTO>()
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src =>src.Bookings));

            //Create automapper for creation the promocode
            CreateMap<PromocodeCreateDTO, Promocode>();

            //Create automapper for updating the promocode
            CreateMap<PromocodeUpdateDTO, Promocode>();
        }
    }
}
