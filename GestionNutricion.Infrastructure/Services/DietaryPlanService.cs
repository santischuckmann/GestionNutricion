using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.Query.Handlers;
using GestionNutricion.Infrastructure.Repositories;
using System.Runtime.ExceptionServices;

namespace GestionNutricion.Infrastructure.Services
{
    public class DietaryPlanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DietaryPlanQueryHandler _queryHandler;
        public DietaryPlanService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            DietaryPlanQueryHandler dietaryPlanQueryHandler) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _queryHandler = dietaryPlanQueryHandler ?? throw new ArgumentNullException(nameof(dietaryPlanQueryHandler));

        }
        public async Task CreateDietaryPlan(DietaryPlanInsertionDto newDietaryPlanDto, int userId)
        {
            var dietaryPlan = _mapper.Map<DietaryPlan>(newDietaryPlanDto);

            dietaryPlan.PlanSnacks = dietaryPlan.PlanSnacks.Where(ps => ps.Food != String.Empty).ToList();

            Patient patient;
            if (newDietaryPlanDto.PatientId != null)
                patient = await _unitOfWork.PatientRepository.GetById((int)newDietaryPlanDto.PatientId);
            else
                patient = new Patient()
                {
                    IsActive = 1,
                    FirstAppointmentDate = DateTime.Now,
                    LastAppointmentDate = DateTime.Now,
                    Name = newDietaryPlanDto.Name,
                    Surname = newDietaryPlanDto.Surname,
                    UserId = userId
                };

            dietaryPlan.Patient = patient;

            await _unitOfWork.DietaryPlanRepository.Add(dietaryPlan);

            List<Snack> snacksToInsert = new();
            foreach (var planSnack in dietaryPlan.PlanSnacks)
            {
                var snackExists = _unitOfWork.SnackRepository.DoesSnackExistByName(planSnack.Food);
                if (!snackExists)
                {
                    var snack = new Snack { Food = planSnack.Food, IdSnackTime = planSnack.IdSnackTime };
                    snacksToInsert.Add(snack);
                }
            }
            await _unitOfWork.SnackRepository.AddList(snacksToInsert);

            await _unitOfWork.SaveAsync();
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
            var dietaryPlan = await _unitOfWork.DietaryPlanRepository.GetDietaryPlanById(dietaryPlanDto.DietaryPlanId);

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

            _unitOfWork.DietaryPlanRepository.Update(dietaryPlan);
            await _unitOfWork.SaveAsync();
        }
    }
}
