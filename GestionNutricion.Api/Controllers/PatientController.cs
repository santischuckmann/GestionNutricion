using CedServicios.Api.Controllers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.Patient;
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PatientDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPatients()
        {
            IEnumerable<PatientDto> plans = await _patientService.GetPatients(AuthenticatedUserId);

            return Ok(plans);
        }
        [HttpGet("{patientId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetailedPatientDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPatient(int patientId)
        {
            DetailedPatientDto patient = await _patientService.GetPatient(patientId, AuthenticatedUserId);

            return Ok(patient);
        }
    }
}
