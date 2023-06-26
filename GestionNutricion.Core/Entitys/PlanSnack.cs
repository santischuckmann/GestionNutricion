﻿namespace GestionNutricion.Core.Entitys
{
    public class PlanSnack: CommonEntity
    {
        public int IdDietaryPlan { get; set; }
        public string Food { get; set; }
        public int IdSnackTime { get; set; }
        public virtual DietaryPlan DietaryPlan { get; set; }
        public virtual SnackTime SnackTime { get; set; }
    }
}
