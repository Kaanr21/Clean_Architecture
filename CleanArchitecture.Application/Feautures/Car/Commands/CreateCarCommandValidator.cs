using FluentValidation;

namespace CleanArchitecture.Application.Feautures.Car.Commands
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(r => r.name).NotEmpty().WithMessage("Name  cannot be empty");
            RuleFor(r => r.name).NotNull().WithMessage("Name cannot be null");
            RuleFor(r => r.name).MinimumLength(3).WithMessage("Name cannot be under 3 chareacter");

            RuleFor(r => r.model).NotEmpty().WithMessage("model  cannot be empty");
            RuleFor(r => r.model).NotNull().WithMessage("model cannot be null");
            RuleFor(r => r.model).MinimumLength(3).WithMessage("model cannot be under 3 chareacter");

            RuleFor(r => r.enginePower).NotEmpty().WithMessage("enginePower  cannot be empty");
            RuleFor(r => r.enginePower).NotNull().WithMessage("enginePower cannot be null");
            RuleFor(r => r.enginePower).GreaterThan(0).WithMessage("enginePower cannot be under 0");
        }
    }
}
