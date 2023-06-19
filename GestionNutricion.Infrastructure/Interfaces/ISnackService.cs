using GestionNutricion.Infrastructure.DTOs;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface ISnackService
    {
        Task<IEnumerable<SnackDto>> GetAllSnacks();
    }
}
