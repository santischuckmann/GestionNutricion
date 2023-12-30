using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Query;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Text;

namespace GestionNutricion.Infrastructure.Services
{
    public class DietaryPlanService
    {
        private readonly IMapper _mapper;
        private readonly IDietaryPlanCommandHandler _commandHandler;
        private readonly DietaryPlanQueryHandler _queryHandler;
        public DietaryPlanService(
            IMapper mapper, 
            IDietaryPlanCommandHandler dietaryPlanCommandHandler,
            DietaryPlanQueryHandler dietaryPlanQueryHandler) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _commandHandler = dietaryPlanCommandHandler ?? throw new ArgumentNullException(nameof(dietaryPlanCommandHandler));
            _queryHandler = dietaryPlanQueryHandler ?? throw new ArgumentNullException(nameof(dietaryPlanQueryHandler));

        }
        public async Task CreateDietaryPlan(DietaryPlanInsertionDto newDietaryPlanDto, int userId)
        {
            var dietaryPlan = _mapper.Map<DietaryPlan>(newDietaryPlanDto);
            dietaryPlan.UserId = userId;
            Patient newPatient = new Patient()
            {
                IsActive = 1,
                FirstAppointmentDate = DateTime.Now,
                LastAppointmentDate = DateTime.Now,
                Name = newDietaryPlanDto.Name,
                Surname = newDietaryPlanDto.Surname
            };
            dietaryPlan.Patient = newPatient;

            await _commandHandler.AddDietaryPlan(dietaryPlan);
        }

        public async Task<DietaryPlanDto> GetDietaryPlanById(int id)
        {
            var dietaryPlan = await _commandHandler.GetDietaryPlanById(id);

            var dietaryPlanDto = _mapper.Map<DietaryPlanDto>(dietaryPlan);

            return dietaryPlanDto;
        }
        public async Task<List<DietaryPlanDto>> GetDietaryPlans(int userId)
        {
            var dietaryPlanDtos = await Task.Run(() => _queryHandler.GetAllDietaryPlans(userId));

            return dietaryPlanDtos;
        }

        public async Task EditDietaryPlan(DietaryPlanDto dietaryPlanDto)
        {
            var dietaryPlan = await _commandHandler.GetDietaryPlanById(dietaryPlanDto.DietaryPlanId);

            var editedDietaryPlanDto = _mapper.Map<DietaryPlan>(dietaryPlanDto);
            dietaryPlan.PlanSnacks = editedDietaryPlanDto.PlanSnacks;
            dietaryPlan.Breakfast = editedDietaryPlanDto.Breakfast;
            dietaryPlan.MainCourses = editedDietaryPlanDto.MainCourses;
            dietaryPlan.Observations = editedDietaryPlanDto.Observations;

            await _commandHandler.EditDietaryPlan(dietaryPlan);
        }
    }
}
