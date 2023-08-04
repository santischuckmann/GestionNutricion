using CedServicios.Api.Controllers;
using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    public class UserController : GestionNutricionControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        /// <summary>
        /// Get the current authenticated user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("AuthenticatedUser", Name = nameof(GetAuthenticatedUser))]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(UserDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            var user = await _userService.GetUserById(AuthenticatedUserId);

            return Ok(user);
        }
    }
}
