using CedServicios.Api.Controllers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    public class DietaryPlanController : GestionNutricionControllerBase
    {
        private readonly DietaryPlanService _dietaryPlanService;
        public DietaryPlanController(DietaryPlanService dietaryPlanService)
        {
            _dietaryPlanService = dietaryPlanService ?? throw new ArgumentNullException(nameof(dietaryPlanService));
        }
        /// <summary>
        /// Create new Dietary Plan.
        /// </summary>
        /// <param name="dietaryPlanDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(DietaryPlanDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateDietaryPlan(DietaryPlanInsertionDto dietaryPlanDto)
        { 
            DietaryPlanDto result = await _dietaryPlanService.CreateDietaryPlan(dietaryPlanDto);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IEnumerable<DietaryPlanDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDietaryPlans()
        {
            IEnumerable<DietaryPlanDto> plans = await _dietaryPlanService.GetDietaryPlans(AuthenticatedUserId);

            return Ok(plans);
        }
    }
}
