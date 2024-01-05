namespace GestionNutricion.Core.Entitys
{
    public class MainCourse: CommonEntity
    {
        public int MainCourseId { get; set; }
        public int IdMainCourseType { get; set; }
        public string Food { get; set; }
        public string Dessert { get; set; }
        public int DietaryPlanId { get; set; }
        public virtual MainCourseType MainCourseType { get; set; }
        public virtual DietaryPlan DietaryPlan { get; set; }
    }
}
