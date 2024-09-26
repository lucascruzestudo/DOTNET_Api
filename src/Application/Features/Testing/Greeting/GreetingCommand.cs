using MediatR;
namespace Application.Features.Testing.Greeting;
public class GreetingCommand(string name, int age) : IRequest<GreetingCommandResponse>
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
}
