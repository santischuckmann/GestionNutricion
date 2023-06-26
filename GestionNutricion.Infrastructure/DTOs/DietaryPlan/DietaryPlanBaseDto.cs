namespace GestionNutricion.Infrastructure.DTOs.DietaryPlan
{
    public abstract class DietaryPlanBaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Observations { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
    }
}
