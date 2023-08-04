using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.Snack;

namespace GestionNutricion.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() {
            CreateMap<PlanSnackDto, Snack>().ReverseMap();
            CreateMap<PlanSnackInsertionDto, Snack>().ReverseMap();

            CreateMap<DietaryPlanDto, DietaryPlan>().ReverseMap();
            CreateMap<DietaryPlanInsertionDto, DietaryPlan>().ReverseMap();

            CreateMap<PlanSnackInsertionDto, PlanSnack>().ReverseMap();
            CreateMap<PlanSnackDto, PlanSnack>().ReverseMap();

            CreateMap<MainCourseInsertionDto, MainCourse>().ReverseMap();
            CreateMap<MainCourseDto, MainCourse>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
