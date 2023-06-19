using GestionNutricion.Core.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Repositories
{
    public interface IRepository<T> where T : CommonEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task Add(T entity);

        void Update(T entity);

        Task Delete(int id);

        Task AddList(IEnumerable<T> entities);

        void UpdateList(IEnumerable<T> entity);
        System.Linq.IQueryable<T> GetAllQuery();
    }
}