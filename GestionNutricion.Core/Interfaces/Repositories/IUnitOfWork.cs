using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Interfaces.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        ISnackRepository SnackRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
