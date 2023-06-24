using GestionNutricion.Infrastructure.DTOs.Snack;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface ISnackService
    {
        Task<IEnumerable<SnackDto>> GetAllSnacks();
        Task<SnackDto> AddSnack(SnackInsertionDto newSnackDto);
    }
}
