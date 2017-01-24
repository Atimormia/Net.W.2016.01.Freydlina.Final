using System;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Commit();
    }
}
