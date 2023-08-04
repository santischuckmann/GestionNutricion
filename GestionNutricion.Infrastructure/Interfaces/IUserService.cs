using GestionNutricion.Infrastructure.DTOs;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int userId);
    }
}
