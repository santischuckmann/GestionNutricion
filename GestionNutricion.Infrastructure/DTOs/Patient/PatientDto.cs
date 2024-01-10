using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs.Patient
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime FirstAppointmentDate { get; set; }
        public DateTime LastAppointmentDate { get; set; }
        public bool IsActive { get; set; }
        public int DietaryPlanCount { get; set; }
    }
}
