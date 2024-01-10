using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.PlanSnack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.DietaryPlan
{
    public class DietaryPlanInsertionDto : DietaryPlanBaseDto
    {
        public int? PatientId { get; set; }
        public List<MainCourseInsertionDto> MainCourses { get; set; }
        public List<PlanSnackInsertionDto> PlanSnacks { get; set; }
    }
}
