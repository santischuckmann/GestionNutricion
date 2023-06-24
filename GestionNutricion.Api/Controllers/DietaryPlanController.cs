using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryPlanController : ControllerBase
    {
        private readonly IDietaryPlanService _dietaryPlanService;
        public DietaryPlanController(IDietaryPlanService dietaryPlanService)
        {
            _dietaryPlanService = dietaryPlanService ?? throw new ArgumentNullException(nameof(dietaryPlanService));
        }
        /// <summary>
        /// Create new Dietary Plan.
        /// </summary>
        /// <param name="dietaryPlanDto"></param>
        /// <returns></returns>
        [HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(DietaryPlanDTO))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateDietaryPlan(DietaryPlanInsertionDto dietaryPlanDto)
        { 
            var result = await _dietaryPlanService.CreateDietaryPlan(dietaryPlanDto);

            return Ok(result);
        }
    }
}
