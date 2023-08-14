using Application.Common.DTO;

namespace Application.Sessions.DTO
{
    public record AddUserToSessionDTO : CreateDTO
    {
        public required string UserId { get; set; }

        public required string SessionId { get; set; }
    }
}
