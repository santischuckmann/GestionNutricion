using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Interfaces.Repositories
{
    public interface IDietaryPlanRepository : IRepository<DietaryPlan>
    {
        public Task<IEnumerable<DietaryPlan>> GetAllDietaryPlans(int userId);
    }
}
