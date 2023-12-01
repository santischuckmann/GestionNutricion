using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Handlers;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;

namespace GestionNutricion.Infrastructure.Services
{
    public class DietaryPlanService
    {
        private readonly IMapper _mapper;
        private readonly IDietaryPlanHandler _dietaryPlanHandler;
        public DietaryPlanService(IMapper mapper, IDietaryPlanHandler dietaryPlanHandler) { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dietaryPlanHandler = dietaryPlanHandler ?? throw new ArgumentNullException(nameof(dietaryPlanHandler));
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

            await _dietaryPlanHandler.AddDietaryPlan(dietaryPlan);
        }

        public async Task<DietaryPlanDto> GetDietaryPlanById(int id)
        {
            var dietaryPlan = await _dietaryPlanHandler.GetDietaryPlanById(id);

            var dietaryPlanDto = _mapper.Map<DietaryPlanDto>(dietaryPlan);

            return dietaryPlanDto;
        }
        public async Task<IEnumerable<DietaryPlanDto>> GetDietaryPlans(int userId)
        {
            var dietaryPlan = await _dietaryPlanHandler.GetAllDietaryPlans(userId);

            var dietaryPlanDto = _mapper.Map<IEnumerable<DietaryPlanDto>>(dietaryPlan);

            return dietaryPlanDto;
        }
    }
}
