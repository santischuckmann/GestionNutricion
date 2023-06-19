using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionNutricion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        /// <summary>
        /// Create new Snack.
        /// </summary>
        /// <param name="snackDto"></param>
        /// <returns></returns>
        [HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(DietaryPlanDTO))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateSnack()
        {
            return Ok(null);
        }
    }
}
