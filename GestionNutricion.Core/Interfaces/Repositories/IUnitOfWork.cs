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
        IDietaryPlanRepository DietaryPlanRepository { get; }
        IUserRepository UserRepository { get; }
        IPatientRepository PatientRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
