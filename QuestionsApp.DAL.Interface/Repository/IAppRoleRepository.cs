using System;
using System.Threading.Tasks;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;

namespace QuestionsApp.DAL.Interface.Repository
{
    public interface IAppRoleRepository:IRepository<DalAppUserRole>, IDisposable
    {
        Task<DalAppUserRole> FindByNameAsync(string roleName);
        Task CreateAsync(DalAppUserRole role);
    }
}