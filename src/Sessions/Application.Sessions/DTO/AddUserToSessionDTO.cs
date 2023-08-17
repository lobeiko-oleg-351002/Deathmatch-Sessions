using Application.Common.DTO;

namespace Application.Sessions.DTO
{
    public record AddUserToSessionDTO : RequestDTO
    {
        public required string UserId { get; set; }

        public required string SessionId { get; set; }
    }
}
