using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;

namespace GestionNutricion.Core.Handlers
{
    public class DietaryPlanHandler : IDietaryPlanCommandHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public DietaryPlanHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDietaryPlan(DietaryPlan dietaryPlan)
        {
            await _unitOfWork.DietaryPlanRepository.Add(dietaryPlan);
            await _unitOfWork.SaveAsync();
        }

        public async Task<DietaryPlan> GetDietaryPlanById(int id) => await _unitOfWork.DietaryPlanRepository.GetDietaryPlanById(id);
        public async Task<IEnumerable<DietaryPlan>> GetAllDietaryPlans(int userId) => await _unitOfWork.DietaryPlanRepository.GetAllDietaryPlans(userId);

        public async Task EditDietaryPlan(DietaryPlan dietaryPlan)
        {
            _unitOfWork.DietaryPlanRepository.Update(dietaryPlan);

            await _unitOfWork.SaveAsync();
        }
    }
}
