using Application.PlayerProfiles.Commands;
using MassTransit;
using MediatR;
using MicroserviceEvents;

namespace Application.PlayerProfiles.Consumer;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IMediator _mediator;

    public UserCreatedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        await _mediator.Send(new CreatePlayerProfileCommand { Name = context.Message.Name, UserId = context.Message.UserId });
    }
}
