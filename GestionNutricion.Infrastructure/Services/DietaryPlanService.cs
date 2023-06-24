using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Handlers;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Interfaces;

namespace GestionNutricion.Infrastructure.Services
{
    public class DietaryPlanService : IDietaryPlanService
    {
        private readonly IMapper _mapper;
        private readonly IDietaryPlanHandler _dietaryPlanHandler;
        public DietaryPlanService(IMapper mapper, IDietaryPlanHandler dietaryPlanHandler) { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dietaryPlanHandler = dietaryPlanHandler ?? throw new ArgumentNullException(nameof(dietaryPlanHandler));
        }
        public async Task<DietaryPlanDto> CreateDietaryPlan(DietaryPlanInsertionDto newDietaryPlanDto)
        {
            var dietaryPlan = _mapper.Map<DietaryPlan>(newDietaryPlanDto);

            await _dietaryPlanHandler.AddDietaryPlan(dietaryPlan);

            var dietaryPlanDto = _mapper.Map<DietaryPlanDto>(dietaryPlan);

            return dietaryPlanDto;
        }

        public async Task<DietaryPlanDto> GetDietaryPlanById(int id)
        {
            var dietaryPlan = await _dietaryPlanHandler.GetDietaryPlanById(id);

            var dietaryPlanDto = _mapper.Map<DietaryPlanDto>(dietaryPlan);

            return dietaryPlanDto;
        }
    }
}
