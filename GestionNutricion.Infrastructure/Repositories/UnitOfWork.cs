using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly GestionNutricionContext _context;
        private readonly ISnackRepository _snackRepository;
        private readonly IDietaryPlanRepository _dietaryPlanRepository;
        public UnitOfWork(GestionNutricionContext context)
        {
            _context = context;
        }

        public ISnackRepository SnackRepository => _snackRepository ?? new SnackRepository(_context);
        public IDietaryPlanRepository DietaryPlanRepository => _dietaryPlanRepository ?? new DietaryPlanRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
