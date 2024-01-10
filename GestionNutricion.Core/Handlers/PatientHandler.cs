using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;

namespace GestionNutricion.Core.Handlers
{
    public class PatientHandler : IPatientCommandHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public PatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> GetPatientById(int id) => await _unitOfWork.PatientRepository.GetById(id);
    }
}
