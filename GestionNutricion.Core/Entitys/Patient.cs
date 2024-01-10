using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Entitys
{
    public class Patient: CommonEntity
    {
        public Patient() 
        { 
            DietaryPlans = new HashSet<DietaryPlan>();
        }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime FirstAppointmentDate { get; set; }
        public DateTime LastAppointmentDate { get; set; }
        public byte IsActive { get; set; }
        public virtual ICollection<DietaryPlan> DietaryPlans { get; set; }

    }
}
