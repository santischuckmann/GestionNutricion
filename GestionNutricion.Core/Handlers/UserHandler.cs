using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Handlers
{
    public class UserHandler : IUserHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public UserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserById(int userId) => await _unitOfWork.UserRepository.GetById(userId);
    }
}
