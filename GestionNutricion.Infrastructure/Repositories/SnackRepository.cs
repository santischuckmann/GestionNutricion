using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class SnackRepository : BaseRepository<Snack>, ISnackRepository
    {
        private readonly GestionNutricionContext _gestionNutricionContext;
        public SnackRepository(GestionNutricionContext context) : base(context) 
        {
            _gestionNutricionContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public bool DoesSnackExistByName(string name) => _gestionNutricionContext.Snacks.Where(s => s.Food.Equals(name)).Any();
    }
}

