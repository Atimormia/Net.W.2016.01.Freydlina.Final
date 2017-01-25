using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
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
            try
            {
                await DataContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"DbUpdateException error details - {e.InnerException?.InnerException?.Message}");
                foreach (var eve in e.Entries)
                    sb.AppendLine($"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated");
                Debug.Write(sb.ToString());
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                        Debug.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
            }
        }

        public void Commit()
        {
            try
            {
                DataContext?.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"DbUpdateException error details - {e.InnerException?.InnerException?.Message}");
                foreach (var eve in e.Entries)
                    sb.AppendLine($"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated");
                Debug.Write(sb.ToString());
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                        Debug.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
            }
        }
        
    }
}
