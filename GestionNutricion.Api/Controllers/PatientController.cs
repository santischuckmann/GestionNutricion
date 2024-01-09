using CedServicios.Api.Controllers;
using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionNutricion.Api.Controllers
{
    public class PatientController: GestionNutricionControllerBase
    {
        private readonly PatientService _patientService;
        public PatientController(PatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IEnumerable<PatientDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPatients()
        {
            IEnumerable<PatientDto> plans = await _patientService.GetPatients(AuthenticatedUserId);

            return Ok(plans);
        }
    }
}
