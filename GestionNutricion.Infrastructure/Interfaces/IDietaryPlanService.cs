using GestionNutricion.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Interfaces
{
    public interface IDietaryPlanService
    {
        Task CreateDietaryPlan(DietaryPlanDto newDietaryPlan);
        Task<DietaryPlanDto> GetDietaryPlanById(int id);
    }
}
