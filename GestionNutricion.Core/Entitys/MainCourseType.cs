using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Entitys
{
    public class MainCourseType: MasterTableEntity
    {
        public MainCourseType() 
        {
            MainCourses = new HashSet<MainCourse>();
        }
        public int MainCourseTypeId { get; set; }
        public ICollection<MainCourse> MainCourses { get; set; }
    }
}
