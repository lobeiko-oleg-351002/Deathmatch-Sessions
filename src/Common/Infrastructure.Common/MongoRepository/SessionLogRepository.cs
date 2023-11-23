using Domain.Interfaces;
using MongoDB.Driver;
using Domain.Entities;

namespace Infrastructure.Common.MongoRepository
{
    public class SessionLogRepository : ILoggerRepository
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName = "SessionLog";
        public SessionLogRepository(IMongoDatabase database) 
        { 
            _database = database;
        }

        public async void AddLogRecord(SessionLog message)
        {
            await _database.GetCollection<SessionLog>(_collectionName).InsertOneAsync(message);
        }
    }
}
