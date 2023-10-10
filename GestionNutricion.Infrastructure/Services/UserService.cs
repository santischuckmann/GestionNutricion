using AutoMapper;
using GestionNutricion.Core.Handlers;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Services
{
    public class UserService
    {
        private readonly IUserHandler _userHandler;
        private readonly IMapper _mapper;
        public UserService(IUserHandler userHandler, IMapper mapper)
        {
            _userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userHandler.GetUserById(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
