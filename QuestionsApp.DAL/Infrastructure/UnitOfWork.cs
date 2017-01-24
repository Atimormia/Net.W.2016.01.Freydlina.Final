using System;
using System.Data.Entity;
using System.Threading.Tasks;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.ORM.EF;

namespace QuestionsApp.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private ApplicationDbContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected ApplicationDbContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }
        
        public async Task SaveAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public void Commit()
        {
            DataContext?.SaveChanges();
        }
        
    }
}
