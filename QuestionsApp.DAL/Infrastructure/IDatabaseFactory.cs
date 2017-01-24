using System;
using QuestionsApp.ORM.EF;

namespace QuestionsApp.DAL.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }
}
