using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface IUserService
    {
        AppUserEntity GetUserEntity(int id);
        IEnumerable<AppUserEntity> GetAllUserEntities();

        //void CreateUser(AppUserEntity userEntity);
        void DeleteUser(AppUserEntity user);

        Task<OperationDetails> Create(AppUserEntity userEntity);
        Task<ClaimsIdentity> Authenticate(AppUserEntity userEntity);
        Task SetInitialData(AppUserEntity adminEntity, List<string> roles);
        Task<ClaimsIdentity> CreateIdentityAsync(AppUserEntity user, string authenticationType);
        Task<AppUserEntity> FindAsync(string email, string password);
        Task<bool> ConfirmEmailAsync(string userId, string code);
        Task<AppUserEntity> FindByNameAsync(string email);
        Task<bool> IsEmailConfirmedAsync(string id);
        Task<IEnumerable<string>> ResetPasswordAsync(string id, string code, string password);
        Task<IEnumerable<string>> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<AppUserEntity> FindByIdAsync(string userId);
    }


}
