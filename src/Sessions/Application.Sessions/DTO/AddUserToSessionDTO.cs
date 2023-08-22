using Application.Common.DTO;

namespace Application.Sessions.DTO
{
    public record AddUserToSessionDTO : RequestDTO
    {
        public required Guid UserId { get; set; }

        public required Guid SessionId { get; set; }
    }
}
