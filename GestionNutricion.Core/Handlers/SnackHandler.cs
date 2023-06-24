using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Handlers
{
    public class SnackHandler : ISnackHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public SnackHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSnack(Snack snack)
        {
            await _unitOfWork.SnackRepository.Add(snack);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Snack>> GetAllSnacks() => await _unitOfWork.SnackRepository.GetAll();
    }
}
