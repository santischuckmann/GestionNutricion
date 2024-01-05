using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class DietaryPlanRepository : BaseRepository<DietaryPlan>, IDietaryPlanRepository
    {
        private readonly GestionNutricionContext _gestionNutricionContext;
        public DietaryPlanRepository(GestionNutricionContext context) : base(context)
        {
            _gestionNutricionContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<DietaryPlan>> GetAllDietaryPlans(int userId)
        {
            return await _gestionNutricionContext.DietaryPlans
                 .Where(d => d.UserId == userId)
                 .Include(d => d.PlanSnacks)
                 .Include(d => d.MainCourses)
                 .ToListAsync();
        }

        public async Task<DietaryPlan> GetDietaryPlanById(int id)
        {
            return await _gestionNutricionContext.DietaryPlans
                .Where(d => d.DietaryPlanId == id)
                 .Include(d => d.PlanSnacks)
                 .Include(d => d.MainCourses)
                 .Include(d => d.Patient)
                 .FirstAsync();
        }
    }
}

