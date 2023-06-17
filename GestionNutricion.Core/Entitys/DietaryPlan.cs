namespace GestionNutricion.Core.Entitys
{
    public class DietaryPlan: CommonEntity
    {
        public DietaryPlan()
        {
            PlanSnacks = new HashSet<PlanSnack>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Observations { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public virtual ICollection<PlanSnack> PlanSnacks { get; set; }
    }
}
