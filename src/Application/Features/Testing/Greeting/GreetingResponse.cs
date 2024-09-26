namespace Application.Features.Testing.Greeting;

public class GreetingCommandResponse(string message)
{
    public string Message { get; set; } = message;
}
