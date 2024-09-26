using MediatR;
namespace Application.Features.Testing.Greeting;

public class GreetingCommandHandler : IRequestHandler<GreetingCommand, GreetingCommandResponse>
{
    public async Task<GreetingCommandResponse> Handle(GreetingCommand request, CancellationToken cancellationToken)
    {
        var message = $"Olá {request.Name}, sua idade é {request.Age}!";
        return await Task.FromResult(new GreetingCommandResponse(message));
    }
}
