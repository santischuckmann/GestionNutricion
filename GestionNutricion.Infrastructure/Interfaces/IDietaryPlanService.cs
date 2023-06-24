using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface IDietaryPlanService
    {
        Task<DietaryPlanDto> CreateDietaryPlan(DietaryPlanInsertionDto newDietaryPlan);
        Task<DietaryPlanDto> GetDietaryPlanById(int id);
    }
}
