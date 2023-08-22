using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Data;
public abstract class SeederBase<TDbContext, TData> : ISeeder
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    public SeederBase(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public abstract void Execute();
}