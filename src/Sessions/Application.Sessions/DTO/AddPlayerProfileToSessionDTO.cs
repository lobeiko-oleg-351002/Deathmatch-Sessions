using Application.Common.DTO;

namespace Application.Sessions.DTO
{
    public record AddPlayerProfileToSessionDTO : RequestDTO
    {
        public required Guid ProfileId { get; set; }

        public required Guid SessionId { get; set; }
    }
}
