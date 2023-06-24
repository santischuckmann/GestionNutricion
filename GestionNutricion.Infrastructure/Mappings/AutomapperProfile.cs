using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.Snack;

namespace GestionNutricion.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() {
            CreateMap<SnackDto, Snack>().ReverseMap();
            CreateMap<SnackInsertionDto, Snack>().ReverseMap();

            CreateMap<DietaryPlanDto, DietaryPlan>().ReverseMap();
            CreateMap<DietaryPlanInsertionDto, DietaryPlan>().ReverseMap();
        }
    }
}
