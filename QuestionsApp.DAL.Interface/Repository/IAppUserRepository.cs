using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;

namespace QuestionsApp.DAL.Interface.Repository
{
    public interface IAppUserRepository:IRepository<DalAppUser>, IDisposable
    {
        Task<DalAppUser> FindByEmailAsync(string email);
        Task<IEnumerable<string>> CreateAsync(DalAppUser user, string password);
        Task AddToRoleAsync(string userId, string role);
        Task<DalAppUser> FindAsync(string userName, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(DalAppUser user, string authenticationType);
        Task<bool> ConfirmEmailAsync(string userId, string code);
        Task<bool> IsEmailConfirmedAsync(string id);
        Task<IEnumerable<string>> ResetPasswordAsync(string id, string code, string password);
    }
}