using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly GestionNutricionContext _gestionNutricionContext;
        public PatientRepository(GestionNutricionContext context) : base(context)
        {
            _gestionNutricionContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }
    }
}
