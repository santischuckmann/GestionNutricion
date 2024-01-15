using CedServicios.Api.Controllers;
using GestionNutricion.Infrastructure.DTOs.PlanSnack;
using GestionNutricion.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    public class SnackController : GestionNutricionControllerBase
    {
        private readonly SnackService _snackService;
        public SnackController(SnackService snackService)
        {
            _snackService = snackService ?? throw new ArgumentNullException(nameof(snackService));
        }

        /// <summary>
        /// Add new Snack.
        /// </summary>
        /// <param name="snackDto">New Snack to Add</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(PlanSnackDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddSnack(PlanSnackInsertionDto snackDto)
        {
            PlanSnackDto snack = await _snackService.AddSnack(snackDto);

            return Ok(snack);
        }


        /// <summary>
        /// Get Snacks with filters.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSnacks(int snackTimeId)
        {
            IEnumerable<string> snacks = await _snackService.GetSnacks(snackTimeId);

            return Ok(snacks);
        }
    }
}
