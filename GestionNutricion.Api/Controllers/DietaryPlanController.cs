using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryPlanController : ControllerBase
    {
        /// <summary>
        /// Create new Dietary Plan.
        /// </summary>
        /// <param name="dietaryPlanDto"></param>
        /// <returns></returns>
        [HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(DietaryPlanDTO))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateDietaryPlan()
        { 
            return Ok(null);
        }
    }
}
