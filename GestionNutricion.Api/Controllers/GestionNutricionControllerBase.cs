using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CedServicios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GestionNutricionControllerBase : ControllerBase
    {
        protected int AuthenticatedUserId => Convert.ToInt32(User.Claims?.FirstOrDefault(x => x.Type.Equals("idUsuario", StringComparison.OrdinalIgnoreCase))?.Value);
    }
}
