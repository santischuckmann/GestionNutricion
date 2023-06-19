using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionNutricion.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : CommonEntity
    {
        #region Variables
        protected readonly GestionNutricionContext _context;
        protected readonly DbSet<T> _entities;
        #endregion

        #region Constructor
        public BaseRepository(GestionNutricionContext context)
        {
            this._context = context ?? throw new System.ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }
        #endregion

        public IQueryable<T> GetAllQuery()
        {
            return _entities;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddList(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void UpdateList(IEnumerable<T> entity)
        {
            _entities.UpdateRange(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}