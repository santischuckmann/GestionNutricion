using GestionNutricion.Infrastructure.DTOs.Snack;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface ISnackService
    {
        Task<IEnumerable<PlanSnackDto>> GetAllSnacks();
        Task<PlanSnackDto> AddSnack(PlanSnackInsertionDto newSnackDto);
    }
}
