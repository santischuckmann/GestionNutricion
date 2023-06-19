using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Entitys
{
    public class PlanSnack: CommonEntity
    {
        public int IdDietaryPlan { get; set; }
        public string Food { get; set; }
        public TimeSpan IntakeHour { get; set; }
        public virtual DietaryPlan DietaryPlan { get; set; }
    }
}
