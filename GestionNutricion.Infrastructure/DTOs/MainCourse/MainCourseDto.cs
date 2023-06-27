using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.MainCourse
{
    public class MainCourseDto : MainCourseBaseDto
    {
        public int Id { get; set; }
        public int IdDietaryPlan { get; set; }
    }
}
