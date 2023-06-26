namespace GestionNutricion.Infrastructure.DTOs.Snack
{
    public abstract class SnackBaseDto
    {
        public string Food { get; set; }
        public TimeSpan IntakeHour { get; set; }
    }
}
