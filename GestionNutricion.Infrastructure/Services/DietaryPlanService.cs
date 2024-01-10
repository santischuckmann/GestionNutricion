using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Query;

namespace GestionNutricion.Infrastructure.Services
{
    public class DietaryPlanService
    {
        private readonly IMapper _mapper;
        private readonly IDietaryPlanCommandHandler _commandHandler;
        private readonly IPatientCommandHandler _patientCommandHandler;
        private readonly DietaryPlanQueryHandler _queryHandler;
        public DietaryPlanService(
            IMapper mapper, 
            IDietaryPlanCommandHandler dietaryPlanCommandHandler,
            IPatientCommandHandler patientCommandHandler,
            DietaryPlanQueryHandler dietaryPlanQueryHandler) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _commandHandler = dietaryPlanCommandHandler ?? throw new ArgumentNullException(nameof(dietaryPlanCommandHandler));
            _patientCommandHandler = patientCommandHandler ?? throw new ArgumentNullException(nameof(patientCommandHandler));
            _queryHandler = dietaryPlanQueryHandler ?? throw new ArgumentNullException(nameof(dietaryPlanQueryHandler));

        }
        public async Task CreateDietaryPlan(DietaryPlanInsertionDto newDietaryPlanDto, int userId)
        {
            var dietaryPlan = _mapper.Map<DietaryPlan>(newDietaryPlanDto);

            Patient newPatient;
            if (newDietaryPlanDto.PatientId != null)
                newPatient = await _patientCommandHandler.GetPatientById((int)newDietaryPlanDto.PatientId);
            else
                newPatient = new Patient()
                {
                    IsActive = 1,
                    FirstAppointmentDate = DateTime.Now,
                    LastAppointmentDate = DateTime.Now,
                    Name = newDietaryPlanDto.Name,
                    Surname = newDietaryPlanDto.Surname,
                    UserId = userId
                };

            dietaryPlan.Patient = newPatient;

            await _commandHandler.AddDietaryPlan(dietaryPlan);
        }

        public async Task<DietaryPlanDto> GetDietaryPlanById(int id)
        {
            var dietaryPlanDto = await Task.Run(() => _queryHandler.GetDietaryPlanById(id));

            return dietaryPlanDto;
        }
        public async Task<List<DietaryPlanDto>> GetDietaryPlans(int userId)
        {
            var dietaryPlanDtos = await Task.Run(() => _queryHandler.GetAllDietaryPlans(userId));

            return dietaryPlanDtos;
        }

        public async Task EditDietaryPlan(DietaryPlanEditionDto dietaryPlanDto)
        {
            var dietaryPlan = await _commandHandler.GetDietaryPlanById(dietaryPlanDto.DietaryPlanId);

            foreach (var mainCourseDto in dietaryPlanDto.MainCourses)
            {
                var mainCourse = dietaryPlan.MainCourses.Where(m => m.IdMainCourseType == mainCourseDto.IdMainCourseType).FirstOrDefault();

                if (mainCourse == null)
                {
                    MainCourse newMainCourse = new();
                    newMainCourse.Food = mainCourseDto.Food;
                    newMainCourse.Dessert = mainCourseDto.Dessert;
                    newMainCourse.IdMainCourseType = mainCourseDto.IdMainCourseType;
                    dietaryPlan.MainCourses.Add(newMainCourse);
                }
                else
                {
                    mainCourse.Food = mainCourseDto.Food;
                    mainCourse.Dessert = mainCourseDto.Dessert;
                }
            }

            foreach (var planSnackDto in dietaryPlanDto.PlanSnacks)
            {
                var planSnack = dietaryPlan.PlanSnacks.Where(p => p.IdSnackTime == planSnackDto.IdSnackTime).FirstOrDefault();

                if (planSnack == null)
                {
                    PlanSnack newPlanSnack = new();
                    newPlanSnack.Food = planSnackDto.Food;
                    newPlanSnack.IdSnackTime = planSnackDto.IdSnackTime;
                    dietaryPlan.PlanSnacks.Add(newPlanSnack);
                }
                else
                {
                    planSnack.Food = planSnackDto.Food;
                }
            }

            dietaryPlan.Breakfast = dietaryPlanDto.Breakfast;
            dietaryPlan.Observations = dietaryPlanDto.Observations;

            await _commandHandler.EditDietaryPlan(dietaryPlan);
        }
    }
}
