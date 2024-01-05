using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.Snack;
using System.Text;

namespace GestionNutricion.Infrastructure.DTOs.DietaryPlan
{
    public class DietaryPlanDto: DietaryPlanBaseDto
    {
        public int DietaryPlanId { get; set; }
        public List<MainCourseDto> MainCourses { get; set; }
        public List<PlanSnackDto> PlanSnacks { get; set; }
    }
}
