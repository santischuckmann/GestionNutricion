using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;

namespace GestionNutricion.Core.Handlers
{
    public class DietaryPlanHandler : IDietaryPlanHandler
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

        public async Task<DietaryPlan> GetDietaryPlanById(int id) => await _unitOfWork.DietaryPlanRepository.GetById(id);
    }
}
