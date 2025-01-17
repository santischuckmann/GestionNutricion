﻿using GestionNutricion.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Interfaces.Handlers
{
    public interface IDietaryPlanCommandHandler
    {
        Task AddDietaryPlan(DietaryPlan dietaryPlan);
        Task<DietaryPlan> GetDietaryPlanById(int id);
        Task<IEnumerable<DietaryPlan>> GetAllDietaryPlans(int userId);
        Task EditDietaryPlan(DietaryPlan dietaryPlan);
    }
}
