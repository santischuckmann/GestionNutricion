using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.Snack;
using GestionNutricion.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        private readonly ISnackService _snackService;
        public SnackController(ISnackService snackService)
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
        /// Get all Snacks.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Snacks", Name = nameof(GetAllSnacks))]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IEnumerable<PlanSnackDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllSnacks()
        {
            IEnumerable<PlanSnackDto> snacks = await _snackService.GetAllSnacks();

            return Ok(snacks);
        }
    }
}
