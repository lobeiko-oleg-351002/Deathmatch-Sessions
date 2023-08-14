using Application.Locations.DTO;
using Application.Locations.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Locations.Commands;
public record CreateLocationCommand : IRequest<Unit>
{
    public required string Name { get; set; }
    public required string LevelFilepath { get; set; }
    public required string PosterFilepath { get; set; }
}

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
{
    private readonly ILocationService _LocationService;
    private readonly IMapper _mapper;
    public CreateLocationCommandHandler(ILocationService LocationService, IMapper mapper)
    {
        _LocationService = LocationService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _LocationService.Create(_mapper.Map<CreateLocationDTO>(request));
        return Unit.Value;
    }
}


