namespace GestionNutricion.Core.Entitys
{
    public class DietaryPlan: CommonEntity
    {
        public DietaryPlan()
        {
            PlanSnacks = new HashSet<PlanSnack>();
            MainCourses = new HashSet<MainCourse>();
        }
        public int DietaryPlanId { get; set; }
        public string Observations { get; set; }
        public string Breakfast { get; set; }
        public int PatientId { get; set; }
        public virtual ICollection<PlanSnack> PlanSnacks { get; set; }
        public virtual ICollection<MainCourse> MainCourses { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
