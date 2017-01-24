using QuestionsApp.ORM.EF;

namespace QuestionsApp.DAL.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private ApplicationDbContext dataContext;
    public ApplicationDbContext Get()
    {
        return dataContext ?? (dataContext = new ApplicationDbContext());
    }
    protected override void DisposeCore()
    {
        dataContext?.Dispose();
    }
}
}
