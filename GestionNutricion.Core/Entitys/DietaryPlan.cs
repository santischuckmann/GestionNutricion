using GestionNutricion.Core.Entitys;

namespace GestionNutricion.Infrastructure.DTOs
{
    public class DietaryPlan
    {
        public DietaryPlan()
        {
            Snacks = new HashSet<Snack>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Observations { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public virtual ICollection<Snack> Snacks { get; set; }
    }
}
