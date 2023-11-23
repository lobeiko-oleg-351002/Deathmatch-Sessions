using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILoggerRepository
    {
        public void AddLogRecord(SessionLog message);
    }
}
