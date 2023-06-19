using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.DTOs
{
    public class SnackDto
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public TimeSpan IntakeHour { get; set; }
    }
}
