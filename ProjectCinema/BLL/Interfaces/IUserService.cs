using ProjectCinema.BLL.DTO.Users;
using ProjectCinema.Entities;

namespace ProjectCinema.BLL.Interfaces
{
    public interface IUserService : IGenericService<UserDTO, User>
    {

        //Регистрация пользователя
        //Авторизация и аутентификация(JWT)
        Task<UserProfileDTO> GetUserProfileDTOByIdAsync(int userId);
        Task<UserDTO> CreateUserAsync(UserCreateDTO userCreateDTO);
        Task<UserDTO> UpdateUserAsync(UserUpdateDTO userUpdateDTO, int userId);

    }
}
