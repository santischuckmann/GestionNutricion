namespace GestionNutricion.Infrastructure.DTOs.Snack
{
    public class PlanSnackDto: PlanSnackBaseDto
    {
        public int Id { get; set; }
        public SnackTimeDto SnackTime { get; set; }
        public int IdDietaryPlan { get; set; }

    }
}
