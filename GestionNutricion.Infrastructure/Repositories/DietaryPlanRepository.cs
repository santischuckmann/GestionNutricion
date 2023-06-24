using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class DietaryPlanRepository : BaseRepository<DietaryPlan>, IDietaryPlanRepository
    {
        private readonly GestionNutricionContext _gestionNutricionContext;
        public DietaryPlanRepository(GestionNutricionContext context) : base(context) 
        {
            _gestionNutricionContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }

    }
}

