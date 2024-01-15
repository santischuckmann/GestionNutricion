using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.Patient;
using GestionNutricion.Infrastructure.Query.Handlers;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Text;

namespace GestionNutricion.Infrastructure.Services
{
    public class PatientService
    {
        private readonly PatientQueryHandler _queryHandler;
        public PatientService(
            PatientQueryHandler patientQueryHandler)
        {
            _queryHandler = patientQueryHandler ?? throw new ArgumentNullException(nameof(patientQueryHandler));

        }

        public async Task<DetailedPatientDto> GetPatient(int patientId, int userId)
        {
            var patientDto = await Task.Run(() => _queryHandler.GetPatient(patientId, userId));

            return patientDto;
        }

        public async Task<List<PatientDto>> GetPatients(int userId)
        {
            var patientDtos = await Task.Run(() => _queryHandler.GetAllPatients(userId));

            return patientDtos;
        }
    }
}
