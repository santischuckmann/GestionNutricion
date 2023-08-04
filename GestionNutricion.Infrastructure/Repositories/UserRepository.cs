using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly GestionNutricionContext _gestionNutricionContext;
        public UserRepository(GestionNutricionContext context) : base(context)
        {
            _gestionNutricionContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }

    }
}

