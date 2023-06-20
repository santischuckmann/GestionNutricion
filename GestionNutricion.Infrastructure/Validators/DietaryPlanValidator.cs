using FluentValidation;
using GestionNutricion.Infrastructure.DTOs;

namespace GestionNutricion.Infrastructure.Validators
{
    public class DietaryPlanValidator: AbstractValidator<DietaryPlanDto>
    {
        public DietaryPlanValidator() {
            RuleFor(d => d.Dinner)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo");
        }
    }
}
