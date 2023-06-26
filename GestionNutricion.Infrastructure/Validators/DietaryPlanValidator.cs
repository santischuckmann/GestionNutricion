using FluentValidation;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;

namespace GestionNutricion.Infrastructure.Validators
{
    public class DietaryPlanValidator: AbstractValidator<DietaryPlanInsertionDto>
    {
        public DietaryPlanValidator() {
            RuleFor(d => d.Dinner)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo")
                .NotEmpty()
                .WithMessage("Tiene que indicar una cena para el paciente");

            RuleFor(d => d.Breakfast)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo")
                .NotEmpty()
                .WithMessage("Tiene que indicar una cena para el paciente");

            RuleFor(d => d.Surname)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo")
                .NotEmpty()
                .WithMessage("Tiene que indicar un apellido para el paciente");

            RuleFor(d => d.Observations)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo");

            RuleFor(d => d.Name)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo")
                .NotEmpty()
                .WithMessage("Tiene que indicar un nombre para el paciente");

            RuleFor(d => d.Lunch)
                .MinimumLength(5)
                .WithMessage("Poneme mas letras pelotudo")
                .NotEmpty()
                .WithMessage("Tiene que indicar un almuerzo para el paciente");

        }
    }
}
