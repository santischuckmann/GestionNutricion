namespace GestionNutricion.Core.Entitys
{
    public class Snack: CommonEntity
    {
        public int SnackId { get; set; }
        public string Food { get; set; }
        public int? IdSnackTime { get; set; }
        public virtual SnackTime SnackTime { get; set; }
    }
}
