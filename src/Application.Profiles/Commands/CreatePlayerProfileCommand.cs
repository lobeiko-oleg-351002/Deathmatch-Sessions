using Application.PlayerProfiles.DTO;
using Application.PlayerProfiles.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PlayerProfiles.Commands;
public record CreatePlayerProfileCommand : IRequest<Unit>
{
    public required string Name { get; set; }
    public required Guid UserId { get; set; }
}

public class CreatePlayerProfileCommandHandler : IRequestHandler<CreatePlayerProfileCommand, Unit>
{
    private readonly IPlayerProfileService _ProfileService;
    private readonly IMapper _mapper;
    public CreatePlayerProfileCommandHandler(IPlayerProfileService ProfileService, IMapper mapper)
    {
        _ProfileService = ProfileService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreatePlayerProfileCommand request, CancellationToken cancellationToken)
    {
        await _ProfileService.Create(_mapper.Map<CreatePlayerProfileDTO>(request));
        return Unit.Value;
    }
}


