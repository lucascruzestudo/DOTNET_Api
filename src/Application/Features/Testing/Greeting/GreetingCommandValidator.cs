using FluentValidation;
namespace Application.Features.Testing.Greeting;

public class GreetingCommandValidator : AbstractValidator<GreetingCommand>
{
    public GreetingCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(command => command.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.");
    }
}
