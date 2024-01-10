using GestionNutricion.Infrastructure.DTOs.DietaryPlan;

namespace GestionNutricion.Infrastructure.DTOs.PlanSnack
{
    public abstract class PlanSnackBaseDto
    {
        public string Food { get; set; }
        public int IdSnackTime { get; set; }
    }
}
