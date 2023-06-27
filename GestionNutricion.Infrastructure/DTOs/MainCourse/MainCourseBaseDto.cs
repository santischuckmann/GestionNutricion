using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.MainCourse
{
    public abstract class MainCourseBaseDto
    {
        public int IdMainCourseType { get; set; }
        public string Food { get; set; }
        public string Dessert { get; set; }
    }
}
