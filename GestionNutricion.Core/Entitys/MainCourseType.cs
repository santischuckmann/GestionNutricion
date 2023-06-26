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
            DietaryPlans = new HashSet<DietaryPlan>();
        }
        public ICollection<DietaryPlan> DietaryPlans { get; set; }
    }
}
