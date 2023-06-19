using System;
namespace GestionNutricion.Core.Entitys
{
    public class Snack: CommonEntity
    {
        public string Food { get; set; }
        public TimeSpan IntakeHour { get; set; }
    }
}
