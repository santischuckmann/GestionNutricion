namespace GestionNutricion.Core.Entitys
{
    public class SnackTime: MasterTableEntity
    {
        public SnackTime() 
        {
            Snacks = new HashSet<Snack>();
            PlanSnacks = new HashSet<PlanSnack>(); 
        }
        public ICollection<Snack> Snacks { get; set; }
        public ICollection<PlanSnack> PlanSnacks { get; set; }
    }
}
