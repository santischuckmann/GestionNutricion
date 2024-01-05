namespace GestionNutricion.Infrastructure.DTOs.Snack
{
    public class PlanSnackDto: PlanSnackBaseDto
    {
        public int Id { get; set; }
        public int DietaryPlanId { get; set; }
    }
}
