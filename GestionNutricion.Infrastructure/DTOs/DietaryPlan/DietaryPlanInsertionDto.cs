using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.Snack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.DietaryPlan
{
    public class DietaryPlanInsertionDto : DietaryPlanBaseDto
    {
        public List<MainCourseInsertionDto> MainCourses { get; set; }
        public List<PlanSnackInsertionDto> PlanSnacks { get; set; }
    }
}
