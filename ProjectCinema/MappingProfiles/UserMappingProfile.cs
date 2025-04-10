using AutoMapper;
using ProjectCinema.BLL.DTO.Users;
using ProjectCinema.Entities;

namespace ProjectCinema.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Create automapper for general user view
            CreateMap<User, UserDTO>();

            // Create automapper for detail information 
            CreateMap<User, UserProfileDTO>().ForMember(dest => dest.Bookings, opt => opt
                                             .MapFrom(src => src.Bookings));

            //Create automapper for creation a user
            CreateMap<UserCreateDTO, User>();

            // Create automapper for update a user
            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

        }

    }
}
