using GestionNutricion.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.DietaryPlan
{
    public class DietaryPlanEditionDto
    {
        public int DietaryPlanId { get; set; }
        public string Breakfast { get; set; }
        public string Observations { get; set; }
        public List<MainCourse.MainCourseDto> MainCourses { get; set; }
        public List<PlanSnack.PlanSnackDto> PlanSnacks { get; set; }
    }
}
