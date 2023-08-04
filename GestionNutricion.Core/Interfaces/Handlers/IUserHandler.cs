using GestionNutricion.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Core.Interfaces.Handlers
{
    public interface IUserHandler
    {
        Task<User> GetUserById(int userId);
    }
}
